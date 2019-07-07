using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;
using AssetManagement.Object.Services;

namespace AssetManagement.Domain.Interfaces
{
    public interface IReleaseAssetsProcess
    {
        ReleaseOutput ReleaseAsset(AssetBase newAsset, IResulotionConverter converter);
    }
}