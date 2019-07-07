using Microsoft.AspNetCore.Builder;

namespace AssetManagement.Api.Utility.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureGlobalExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
