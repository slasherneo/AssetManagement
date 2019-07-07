using AssetManagement.Domain.Entities;
using AssetManagement.Object.Assets;
using System.Collections.Generic;

namespace AssetManagement.Domain.Factories
{
    public interface IAssetFactory
    {
        AssetEntityBase CreateAssets(AssetBase newAsset);
    }
}
