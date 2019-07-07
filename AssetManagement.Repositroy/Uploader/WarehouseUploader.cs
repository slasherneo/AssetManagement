using AssetManagement.Object.Assets;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace AssetManagement.Repository.Uploader
{
    public class WarehouseUploader : IWarehouseUploader
    {
        private readonly HttpClient client;
        private string _warehouseServer;

        public WarehouseUploader(IHttpClientFactory client, IConfiguration configuration)
        {
            this.client = client.CreateClient();
            _warehouseServer = configuration["Warehouse:RegistryApi"];
        }
        //TODO save to DW.
        public bool Upload2Warehouse(string id, string assetsPath,Resolution resolution)
        {
            //client.SendAsync(_warehouseServer, request);
            return true;
        }
    }
}
