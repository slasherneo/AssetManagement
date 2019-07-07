using AssetManagement.Domain.Factories;
using AssetManagement.Domain.Interfaces;
using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;
using AssetManagement.Object.Services;

namespace AssetManagement.Domain.Services
{
    public class ReleaseAssetsProcess : IReleaseAssetsProcess
    {
        private readonly IAssetFactory _assetFactory;

        public ReleaseAssetsProcess(IAssetFactory assetFactory)
        {
            _assetFactory = assetFactory;
        }

        public ReleaseOutput ReleaseAsset(AssetBase newAsset, IResulotionConverter converter)
        {
            ReleaseOutput output = new ReleaseOutput();

            var candidateAsset = _assetFactory.CreateAssets(newAsset);

            candidateAsset.ConvertResolution(converter);

            output.Id = candidateAsset.Id;
            output.Result = candidateAsset.UploadEntity();

            return output;
        }
    }
}
