using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Session2.common
{
    public class TranslateText
    {
        public string key {get;set;}
        public String Translate { get; set; }
    }

    public class TranslationHelper
    {   
         List<TranslateText> lstTranslateTexts;
        public TranslationHelper(IHostEnvironment _env)
        {
            //Check translate avalialbel on cache or note
            //-> get from cache


            //If not exist in cache
            String currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            String filePath = Path.Combine(_env.ContentRootPath, "Resources", "Translations", $"{currentCulture}.json");

            using(StreamReader file = File.OpenText(filePath))
            {
                lstTranslateTexts = JsonConvert.DeserializeObject<List<TranslateText>>(file.ReadToEnd());
            }
            
            //Store translate to cache
        
        }

        public String getTranslate(string key)
        {
            TranslateText translate = lstTranslateTexts.FirstOrDefault(t=>t.key == key);
            if(translate!=null)
            {
                return translate.Translate;
            }
            return key;
        }
    }
}