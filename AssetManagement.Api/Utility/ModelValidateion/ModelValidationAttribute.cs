using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AssetManagement.Api.Models;

namespace AssetManagement.Api.Utility.ModelValidateion
{
    public sealed class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting (ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var resultContent = new ResponseBase () { ReturnCode = "97", ReturnMessage = "輸入資料錯誤" };
                context.Result = new BadRequestObjectResult (resultContent);
            }
        }
    }
}