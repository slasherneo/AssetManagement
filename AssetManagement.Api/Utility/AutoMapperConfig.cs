﻿using AssetManagement.Api.Models;
using AssetManagement.Object.Assets;
using AutoMapper;

namespace AssetManagement.Api.Utility
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ReleaseVedioRequest, VedioAsset>();
                cfg.CreateMap<ReleaseGraphicRequest, GraphicAsset>();
                
            }
            );
        }
    }
}
