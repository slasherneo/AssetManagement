using AssetManagement.Object.Assets;
using System.Threading.Tasks;

namespace AssetManagement.Domain.ResolutionConvter
{
    public interface IResulotionConverter
    {
        string ConvertVedioSource(string sourcePath, Resolution resolution);
        string ConvertGraphicSource(string sourcePath, Resolution resolution);
    }
}
