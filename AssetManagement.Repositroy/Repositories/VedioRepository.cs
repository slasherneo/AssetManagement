using AssetManagement.Object.Assets;
using AssetManagement.Repository.Interfaces;
using AssetManagement.Repository.Uploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AssetManagement.Repository.Repositories
{
    public class VedioRepository : IVedioRepository
    {
        List<VedioAsset> context = new List<VedioAsset>();
        private readonly IWarehouseUploader _warehouseUploader;

        public VedioRepository(IWarehouseUploader warehouseUploader)
        {
            _warehouseUploader = warehouseUploader;
        }

        public VedioAsset Create(VedioAsset vedio)
        {            
            context.Add(vedio);
            foreach(var resoVedio in vedio.Vedios)
            {
                _warehouseUploader.Upload2Warehouse(vedio.Id, resoVedio.VedioPath, resoVedio.Resolution);
            }
            return vedio;
        }

        public IEnumerable<VedioAsset> Find(Expression<Func<VedioAsset,bool>> query)
        {
            return context.AsQueryable().Where(query);
        }

        public VedioAsset Update(VedioAsset vedio)
        {
            var updateVedio = context.FirstOrDefault(x => x.Id == vedio.Id);
            if(updateVedio == default(VedioAsset))
            {
                context.Add(vedio);
            }
            else
            {
                updateVedio = vedio;
            }
            return vedio;
        }

        public void Delete(VedioAsset vedio)
        {
            var updateVedio = context.FirstOrDefault(x => x.Id == vedio.Id);
            if (updateVedio != default(VedioAsset))
            {
                updateVedio.IsAvailable = false;
            }
        }
    }
}
