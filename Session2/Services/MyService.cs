using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session2.Services
{
    public interface IMyService{
        public String sayHello();
    }
    public class MyService : IMyService
    {
        private static IMyService _myService;
        private static DateTime createdDate;
        public static IMyService GetInstance()
        {
            if(_myService==null || DateTime.Now.Subtract(createdDate).Minutes>=1)
            {
                _myService = new MyService();
                createdDate = DateTime.Now;
            }
            return _myService;
        }

        private String now;
        public string sayHello()
        {
            if(String.IsNullOrEmpty(now))
                now =  DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            return $"I am My Service. It is {now}";
        }
    }
}