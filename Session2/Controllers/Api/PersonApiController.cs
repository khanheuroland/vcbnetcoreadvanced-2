using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session2.Models;

namespace Session2.Controllers.Api
{
    public class PersonApiController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult GetPerson()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Id = 1, Name = "Ho Xuna Dai", Email="dai.hx@gmail.com", Address="Ha Noi"});
            persons.Add(new Person { Id = 2, Name = "Nguyen Xuan Hung", Email="hung.nx@gmail.com", Address="Ha Noi"});

            return Ok(persons);
        }
    }
}