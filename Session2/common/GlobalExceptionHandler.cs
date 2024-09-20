using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session2.Services;

namespace Session2.common
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //Get Service
            IHelloService helloService = httpContext.RequestServices.GetService<IHelloService>();

            if(httpContext.Response.StatusCode == 500)
            {
                var problemDetail = new ProblemDetails(){
                    Status = httpContext.Response.StatusCode,
                    Title = exception.Message,
                    Detail = exception.StackTrace
                };

                //await httpContext.Response.WriteAsJsonAsync(problemDetail);\
            
                httpContext.Response.Redirect($"/Error/{httpContext.Response.StatusCode}");
            }
            return true;
        }
    }
}