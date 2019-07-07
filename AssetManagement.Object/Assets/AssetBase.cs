using System;

namespace AssetManagement.Object.Assets
{
    public class AssetBase
    {
        public string Id { get; set; }
        public string SourceFilePath { get; set; }
        public DateTime UploadTime { get; set; }
        public AssetMetadata AssetInfo { get; set; }
        public string Author { get; set; }
        public bool IsAvailable {get; set; }
    }

    public class AssetMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SourceFilePath { get; set; }
        public string Version { get; set; }
        public AssetType AssetType { get; set; }
        public string Provider { get; set; }
    }

    public enum AssetType
    {
        Educatoin,Drama,Language
    }

    public enum Resolution
    {
        HighReso, MedReso, LowReso
    }        
}
