using AssetManagement.Api.Models;
using AssetManagement.Domain.Interfaces;
using AssetManagement.Domain.ResolutionConvter;
using AssetManagement.Object.Assets;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AssetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReleaseAssertController : ControllerBase
    {
        private readonly ILogger<ReleaseAssertController> _logger;
        private readonly IReleaseAssetsProcess _service;
        private string   _baseFolder="/temp";

        public ReleaseAssertController(ILogger<ReleaseAssertController> logger, IReleaseAssetsProcess service, IConfiguration configuration)
        {
            _logger = logger;
            _service = service;
            _baseFolder = configuration["TempFolder"];
        }

        /// <summary>
        /// 使用SampleConvert上傳圖片
        /// </summary>
        /// <param name="request">上傳資料(File)</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ResponseBase), 200)]
        public async Task<ResponseBase> ReleaseGraphicAsyncSampleConvterAsync(ReleaseGraphicRequest request)
        {
            string strTag = "ReleaseGrapic";
            var guid = HttpContext.Items["x-guid"];
            HttpContext.Items["x-str-tag"] = strTag;

            _logger.LogInformation($"[{guid}] {strTag} Request : name= {request.Name}");

            var filePath = Path.Combine(_baseFolder, $"{guid.ToString()}.temp");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.Grapic.CopyToAsync(stream);
            }

            var serviceRequest = Mapper.Map<GraphicAsset>(request);
            var converter = new SimpleResulotionConverter();

            var result = new ResponseBase();

            var releaseResult = _service.ReleaseAsset(serviceRequest, converter);
            if (releaseResult.Result)
            {
                result.ReturnCode = "00";
            }
            else
            {
                result.ReturnCode = "99";
            }

            _logger.LogInformation($"[{guid}] {strTag} Response : {JsonConvert.SerializeObject(result)}");

            return result;
        }

        /// <summary>
        /// 使用SampleConvert上傳影片
        /// </summary>
        /// <param name="request">上傳資料(File)</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ResponseBase), 200)]
        public async Task<ResponseBase> ReleaseVedioAsyncSampleConvter(ReleaseVedioRequest request)
        {
            string strTag = "ReleaseVedio";
            var guid = HttpContext.Items["x-guid"];
            HttpContext.Items["x-str-tag"] = strTag;

            _logger.LogInformation($"[{guid}] {strTag} Request : name= {request.Name}");

            var filePath = Path.Combine(_baseFolder, $"{guid.ToString()}.temp");
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.Vedio.CopyToAsync(stream);
            }

            var serviceRequest = Mapper.Map<VedioAsset>(request);
            var converter = new SimpleResulotionConverter();

            var result = new ResponseBase();

            var releaseResult =_service.ReleaseAsset(serviceRequest, converter);
            if (releaseResult.Result)
            {
                result.ReturnCode = "00";
            }
            else
            {
                result.ReturnCode = "99";
            }

            _logger.LogInformation($"[{guid}] {strTag} Response : {JsonConvert.SerializeObject(result)}");

            return result;
        }
    }
}