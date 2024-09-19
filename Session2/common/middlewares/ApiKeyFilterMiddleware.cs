using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session2.common.middlewares
{
    public class ApiKeyFilterMiddleware
    {
        private RequestDelegate _next;
        public ApiKeyFilterMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Headers.ContainsKey("apiKey"))
            {
                await _next(context);
            }
            else
            {
                context.Response.WriteAsync("ApiKey is missing");
                await Task.CompletedTask;
            }
        }
    }

    public static class ApiKeyFilterMiddlewareExtensions
    {
        public static IApplicationBuilder useApiKeyFilter(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiKeyFilterMiddleware>();
        }
    }
}