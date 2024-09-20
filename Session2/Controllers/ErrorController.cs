using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Session2.Controllers
{
    [Route("Error")]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Exception")]
        public IActionResult Exception()
        {
            return Content("Xử lý với exception");
        }

        [HttpGet("404")]
        public IActionResult Error404()
        {
            return View("Error404");
        }

        [HttpGet("500")]
        public IActionResult Error500()
        {
            return View("Error500");
        }
    }
}