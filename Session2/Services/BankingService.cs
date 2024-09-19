using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session2.Services
{
    public interface IBankingService
    {
        public String SayHello();
    }

    public class VCBBankingService:IBankingService
    {
        private String now;
        public String SayHello(){
            if(String.IsNullOrEmpty(now)){
                now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            return $"Hello from VCB Banking Service. Now is: {now}";
        }
    }

    public class VIBBankingService:IBankingService
    {
        private String now;
        
         public String SayHello(){
            if(String.IsNullOrEmpty(now)){
                now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            return $"hello from VIB Banking Service. Now is: {now}";
        }
    }
}