using AssetManagement.Object.Assets;
using Microsoft.AspNetCore.Http;
using System;

namespace AssetManagement.Api.Models
{
    public class ReleaseGraphicRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public AssetType AssetType { get; set; }
        public string Provider { get; set; }
        public DateTime UploadTime { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
        public IFormFile Grapic { get; set; }
        public int Chapter { get; set; }
        public TimeSpan VedioLegth { get; set; }
    }
}
