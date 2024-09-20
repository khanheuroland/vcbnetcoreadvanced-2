using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Session2.Services;

namespace Session2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHelloService _helloService;
        private IServiceProvider serviceProvider;
        private IBankingService myBanking;
        public HomeController(
            ILogger<HomeController> logger, 
            IServiceProvider serviceProvider,
            VCBBankingService myBanking)
        {
            _logger = logger;
            this.serviceProvider = serviceProvider;
            this.myBanking = myBanking;
        }

        public IActionResult Index([FromServices]VIBBankingService bankingService)
        {
            //myBanking = bankingService;
            //return Content(myBanking.SayHello());
            return View();
        }

        public IActionResult Index2()
        {
            return View("Not found");
            /*
            IMyService myService = MyService.GetInstance();
            return Content(myService.sayHello());
            */
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            var exceptionHandlerFeature =HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            /*
            return Problem(
                    detail: exceptionHandlerFeature.Error.StackTrace,
                    title: exceptionHandlerFeature.Error.Message);
            */
            return View("Error");
        }
    }
}