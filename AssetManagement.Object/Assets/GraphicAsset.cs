using System.Collections.Generic;

namespace AssetManagement.Object.Assets
{
    public class GraphicAsset : AssetBase
    {
        public List<GraphicMap> Graphics { get; set; }
    }

    public class GraphicMap
    {
        public Resolution Resolution { get; set; }
        public string GraphicPath { get; set; }
    }
}
