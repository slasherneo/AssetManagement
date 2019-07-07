using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AssetManagement.Object.Assets;

namespace AssetManagement.Repository.Repositories
{
    public interface IGraphicAssetRepository
    {
        GraphicAsset Create(GraphicAsset graphic);
        void Delete(GraphicAsset graphic);
        IEnumerable<GraphicAsset> Find(Expression<Func<GraphicAsset, bool>> query);
        GraphicAsset Update(GraphicAsset graphic);
    }
}