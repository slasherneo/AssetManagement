using AssetManagement.Object.Assets;
using AssetManagement.Repository.Repositories;
using AssetManagement.Repository.Uploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AssetManagement.Repository.Interfaces
{
    public class GraphicAssetRepository : IGraphicAssetRepository
    {       
        List<GraphicAsset> context = new List<GraphicAsset>();
        private readonly IWarehouseUploader _warehouseUploader;

        public GraphicAssetRepository(IWarehouseUploader warehouseUploader)
        {
            _warehouseUploader = warehouseUploader;
        }

        public GraphicAsset Create(GraphicAsset graphic)
        {
            context.Add(graphic);
            foreach (var resoGraphic in graphic.Graphics)
            {
                _warehouseUploader.Upload2Warehouse(graphic.Id, resoGraphic.GraphicPath, resoGraphic.Resolution);
            }
            return graphic;
        }

        public IEnumerable<GraphicAsset> Find(Expression<Func<GraphicAsset, bool>> query)
        {
            return context.AsQueryable().Where(query);
        }

        public GraphicAsset Update(GraphicAsset graphic)
        {
            var updateGraphic = context.FirstOrDefault(x => x.Id == graphic.Id);
            if (updateGraphic == default(GraphicAsset))
            {
                context.Add(graphic);
            }
            else
            {
                updateGraphic = graphic;
            }
            return graphic;
        }

        public void Delete(GraphicAsset graphic)
        {
            var updateGraphic = context.FirstOrDefault(x => x.Id == graphic.Id);
            if (updateGraphic != default(GraphicAsset))
            {
                updateGraphic.AssetInfo.IsAvailable = false;
            }
        }
    }
}
