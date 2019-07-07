using AssetManagement.Object.Assets;

namespace AssetManagement.Repository.Uploader
{
    public interface IWarehouseUploader
    {
        bool Upload2Warehouse(string id, object assets, Resolution resolution);
    }
}
