using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;
using AssetManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class GraphicAssetEntity : AssetEntityBase
    {
        private readonly GraphicAsset _graphicAsset;
        private readonly IGraphicAssetRepository _graphicAssetRepository;

        public GraphicAssetEntity(GraphicAsset graphicAsset, IGraphicAssetRepository graphicAssetRepository )
        {
            _graphicAsset = graphicAsset;
            _graphicAssetRepository = graphicAssetRepository;
        }

        public new string Id { get { return _graphicAsset.Id; } }

        public override void ConvertResolution(IResulotionConverter converter)
        {
            List<GraphicMap> graphics = new List<GraphicMap>();
            var resolutions = Enum.GetValues(typeof(Resolution)).Cast<Resolution>().ToList();

            Parallel.For(0, resolutions.Count, j =>
            {
                var newGraphicPath =  converter.ConvertGraphicSource(_graphicAsset.SourceFilePath, resolutions[j]);
                GraphicMap newGrapicMap = new GraphicMap() { Resolution = resolutions[j], GraphicPath = newGraphicPath };
                graphics.Add(newGrapicMap);
            });
           
            _graphicAsset.Graphics = graphics;
        }

        public override bool UploadEntity()
        {
            _graphicAsset.UploadTime = new DateTime();
            _graphicAssetRepository.Update(_graphicAsset);
            return true;
        }
    }
}
