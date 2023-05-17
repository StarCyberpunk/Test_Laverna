using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Dom
{
    public class DataFromApi
    {
        string ApiKey = "{YOUR_API_KEY}";
        /// <summary>
        /// Получение данных из API
        /// </summary>
        /// <param name="city"> Название города из формы на латинице</param>
        /// <returns>Объект с температурой,описанием и скоростью ветра</returns>
        public async Task<RootViewModel> GetDataAboutCity(string city)
        {
            
            string url = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&lang=ru", city, ApiKey);
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";//Можно GET
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                RootViewModel res = new RootViewModel();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //ответ от сервера
                    var result = streamReader.ReadToEnd();
                    Root otv = JsonConvert.DeserializeObject<Root>(result);
                    res.Temp = (Math.Round( otv.main.temp- 273.15,2)).ToString();
                    res.Description = otv.weather[0].description;
                    res.Wind_speed = otv.wind.speed.ToString();
                    return res;
                    

                    

                }


            }
            catch (Exception ex)
            {
                return new RootViewModel();
            }
        }

    }

    
}
