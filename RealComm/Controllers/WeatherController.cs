using Newtonsoft.Json;
using RealComm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace RealComm.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        static HttpClient client = new HttpClient();
        /// <summary>
        /// Search for city start with q string 
        /// Mock for read from local file city.json can be change in web.config
        /// </summary>
        /// <param name="q"></param>
        /// <returns>List of city that start with q string</returns>
        [HttpGet]
        public List<City> Search(String q)
        {
            

            var Mock = ConfigurationManager.AppSettings["Mock"];
            var key = ConfigurationManager.AppSettings["restapikey"];
            var url = ConfigurationManager.AppSettings["restapiurl"];
            
            List<City> items;
            if (Mock == "true")
            {
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Json//City.json"));
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<City>>(json);
                    return items;
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    String urlfull = String.Format("{0}/locations/v1/cities/autocomplete?apikey={1}&q={2}", url, key,q);
                    var response = client.GetAsync(urlfull).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        items = JsonConvert.DeserializeObject<List<City>>(responseString);
                        return items;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// Weather Data in city with city code 
        /// </summary>
        /// <param name="city">code of city</param>
        /// <returns>Weather Object</returns>
        public Weather GetCurrentWeather(String city)
        {
            var Mock = ConfigurationManager.AppSettings["Mock"];
            var key = ConfigurationManager.AppSettings["restapikey"];
            var url = ConfigurationManager.AppSettings["restapiurl"];
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Json//Weather.json"));
            if ( city == null )
            {
                return null;
            }
            RealComm.Models.Model1 m = new RealComm.Models.Model1();

            var temp = m.Weather
                    .Where(s => s.CityCode == city)
                    .FirstOrDefault();
            if (temp != null) return temp;
            RealComm.Json.WeatherApi item = new RealComm.Json.WeatherApi();
            if (Mock == "true")
            {
                using (StreamReader r = new StreamReader(path))
                {

                    string json = r.ReadToEnd();
                    List<RealComm.Json.WeatherApi> items = JsonConvert.DeserializeObject<List<RealComm.Json.WeatherApi>>(json);
                    item = items[0];

                }
            }
            else
            {

                using (var client = new HttpClient())
                {
                    String urlfull = String.Format("{0}/currentconditions/v1/{1}?apikey={2}", url, city, key);
                    var response = client.GetAsync(urlfull).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        List<RealComm.Json.WeatherApi> items = JsonConvert.DeserializeObject<List<RealComm.Json.WeatherApi>>(responseString);
                        item = items[0];
                    }
                }


            }
            Weather w = new Weather();
            w.CityCode = city;
            w.Temp = item.Temperature.Metric.Value;
            w.WeatherText = item.WeatherText;
            m.Weather.Add(w);
            m.SaveChanges();
            return w;
            ///TODO call api
            ///
        }
    }
    
}
