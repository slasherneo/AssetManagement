using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;

namespace AssetManagement.Domain.Entities
{
    public abstract class AssetEntityBase
    {
        public string Id;

        public abstract void ConvertResolution(IResulotionConverter converter);
        public abstract bool UploadEntity();
    }
}
