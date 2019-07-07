using System;
using System.Collections.Generic;

namespace AssetManagement.Object.Assets
{
    public class VedioAsset : AssetBase
    {
        public List<VedioMap> Vedios { get; set; }
        public int ChapterNumber { get; set; }
        public TimeSpan VedioLegth { get; set; }
    }

    public class VedioMap
    {
        public Resolution Resolution { get; set; }
        public string VedioPath { get; set; }
    }
}
