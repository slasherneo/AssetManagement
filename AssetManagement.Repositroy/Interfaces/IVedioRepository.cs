using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AssetManagement.Object.Assets;

namespace AssetManagement.Repository.Interfaces
{
    public interface IVedioRepository
    {
        VedioAsset Create(VedioAsset vedio);
        void Delete(VedioAsset vedio);
        IEnumerable<VedioAsset> Find(Expression<Func<VedioAsset, bool>> query);
        VedioAsset Update(VedioAsset vedio);
    }
}