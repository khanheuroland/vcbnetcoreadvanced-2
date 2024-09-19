using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session2.common.middlewares
{
    public class SimpleMiddleware
    {
        //Require #1
        private RequestDelegate _next;
        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Require #2
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<p>It is so hot today!</p>");
            _next(context);
            await context.Response.WriteAsync("<p>We have session #3 tomorrow!</p>");
        }
    }

    public static class useSimpleExtensions
    {
        public static IApplicationBuilder useSimple(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SimpleMiddleware>();
        }
    }
}