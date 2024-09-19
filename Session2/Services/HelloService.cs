using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session2.Services
{
    public interface IHelloService
    {
        public String sayHello();
    }
    public class HelloService : IHelloService
    {
        private String now;
        public string sayHello()
        {
            if(String.IsNullOrEmpty(now))
                now = DateTime.Now.ToString("dd/MM/yyy HH:mm");

            return "Hello at "+ now;
        }
    }
}