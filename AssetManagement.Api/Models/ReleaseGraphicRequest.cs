using AssetManagement.Object.Assets;
using Microsoft.AspNetCore.Http;

namespace AssetManagement.Api.Models
{
    public class ReleaseGraphicRequest
    {
        /// <summary>
        /// 圖片名稱
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public AssetType AssetType { get; set; }
        public string Provider { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile Grapic { get; set; }
    }
}
