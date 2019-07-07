using AssetManagement.Domain.Entities;
using AssetManagement.Object.Assets;
using AssetManagement.Repository.Interfaces;
using AssetManagement.Repository.Repositories;

namespace AssetManagement.Domain.Factories
{
    public class AssetFactory : IAssetFactory
    {
        private readonly IGraphicAssetRepository _graphicAssetRepository;
        private readonly IVedioRepository _vedioRepository;

        public AssetFactory(IGraphicAssetRepository graphicAssetRepository, IVedioRepository vedioRepository)
        {
            _graphicAssetRepository = graphicAssetRepository;
            _vedioRepository = vedioRepository;
        }

        public AssetEntityBase CreateAssets(AssetBase assetRequest)
        {
            AssetEntityBase output = default;


            if (assetRequest is GraphicAsset graphicAssetRequest)
            {
                output = new GraphicAssetEntity(graphicAssetRequest, _graphicAssetRepository);
            }
            else if (assetRequest is VedioAsset vedioAssetRequest)
            {
                output = new VedioAssetEntity(vedioAssetRequest, _vedioRepository);
            }
            return output;
        }
    }
}
