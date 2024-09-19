using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Session2.common
{
    public class CacheStorage
    {
        private IDistributedCache distributedCache;
        public CacheStorage(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public void Set(String key, Object data)
        {
            String strData = JsonConvert.SerializeObject(data);
            this.distributedCache.SetString(key, strData);
        }

        public T Get<T>(String key)
        {
            String strDataFromCache = this.distributedCache.GetString(key);
            return JsonConvert.DeserializeObject<T>(strDataFromCache);
        }
    }
}