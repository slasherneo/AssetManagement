using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;
using AssetManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Entities
{
    public class VedioAssetEntity : AssetEntityBase
    {
        private readonly VedioAsset _vedioAsset;
        private readonly IVedioRepository _vedioRepository;

        public VedioAssetEntity(VedioAsset vedioAsset , IVedioRepository vedioRepository)
        {
            _vedioAsset = vedioAsset;
            _vedioRepository = vedioRepository;
        }

        public new string Id { get { return _vedioAsset.Id; } }

        public override void ConvertResolution(IResulotionConverter converter)
        {
            List<VedioMap> vedios = new List<VedioMap>();
            var resolutions = Enum.GetValues(typeof(Resolution)).Cast<Resolution>().ToList();


            Parallel.For(0, resolutions.Count, j =>
            {
                var newVedioPath = converter.ConvertGraphicSource(_vedioAsset.SourceFilePath, resolutions[j]);
                VedioMap newVedioMap = new VedioMap() { Resolution = resolutions[j], VedioPath = newVedioPath };
                vedios.Add(newVedioMap);
            });

            _vedioAsset.Vedios = vedios;
        }

        public override bool UploadEntity()
        {
            _vedioAsset.UploadTime = new DateTime();
            _vedioRepository.Update(_vedioAsset);
            return true;
        }
    }
}
