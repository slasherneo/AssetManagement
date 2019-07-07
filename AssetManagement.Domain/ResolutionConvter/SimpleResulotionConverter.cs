using AssetManagement.Object.Assets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace AssetManagement.Domain.ResolutionConvter
{
    //TODO 提供Resolution maker method
    public class SimpleResulotionConverter : IResulotionConverter
    {
        private readonly string _resoFolder;

        public SimpleResulotionConverter(IConfiguration configuration, IHostingEnvironment env)
        {
            _resoFolder = Path.Combine(env.ContentRootPath, configuration["ResolutionFolder"]);
        }

        public string ConvertGraphicSource(string sourcePath, Resolution resolution)
        {
            var sourceFile = new FileInfo(sourcePath);
            var newFileName = Path.Combine(_resoFolder, $"{sourceFile.Name}-{resolution.ToString()}.graphic");
            File.Copy(sourcePath, newFileName);
            return newFileName;
        }

        public string ConvertVedioSource(string sourcePath, Resolution resolution)
        {
            var sourceFile = new FileInfo(sourcePath);
            var newFileName = Path.Combine(_resoFolder, $"{sourceFile.Name}-{resolution.ToString()}.vedio");
            File.Copy(sourcePath, newFileName);
            return newFileName;
        }
    }
}
