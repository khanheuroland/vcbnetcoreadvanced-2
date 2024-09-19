using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Session2.Models;

namespace Session2.Controllers
{
    public class CachingController : Controller
    {
        private readonly ILogger<CachingController> _logger;
        private IMemoryCache memCache;
        public CachingController(ILogger<CachingController> logger, IMemoryCache _memcache)
        {
            _logger = logger;
            memCache =_memcache;
        }

        //[ResponseCache(Duration =100, Location = ResponseCacheLocation.Client, NoStore =false)]
        public IActionResult Index()
        {
            if(this.memCache.TryGetValue("person", out var result))
            {
                return Ok(result);
            }
            else
            {
                int value = DateTime.Now.Millisecond;

                Person person = new Person(){Id = value, Name="Tran Xuan Soan", Email="soan.tx@gmail.com", Address="Ha Noi"};
                
                this.memCache.Set("person", person, TimeSpan.FromMinutes(5));    

                return Ok(person);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}