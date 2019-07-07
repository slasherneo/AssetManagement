using AssetManagement.Object.Assets;

namespace AssetManagement.Repository.Uploader
{
    public interface IWarehouseUploader
    {
        bool Upload2Warehouse(string id, string assetsPath, Resolution resolution);
    }
}
