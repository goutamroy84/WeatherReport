using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherReport.Model;
using System.Configuration;


namespace WeatherReport
{
    internal  class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            int value = Convert.ToInt32( ConfigurationManager.AppSettings["NumberOfCity"]);
            Console.WriteLine("As per present configuration you will get information of number of City : "+ value);
            for (int i =0;i< value; i++)
            {
                Console.WriteLine("Enter City Name and then press enter");
                string cityName = Console.ReadLine();
                RunAsync(cityName).GetAwaiter().GetResult();
                
            }
            Console.WriteLine("Press any key to Exit");
        }
        
        public  static async Task RunAsync(string cityName)
        {
            // Update port # in the following line.
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://api.open-meteo.com/v1/forecast");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
        
            try
            {
                var product = new WeatherInformation();
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CityInformation\IndiaCity.json");
                if (!File.Exists(path)){
                    path = ConfigurationManager.AppSettings["JsonFileAbsolutePath"].ToString();
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("Please provide permission to file CityInformation-> IndiaCity from Property->Copy To Output Directory as always Copy or put absoluete path value in app.config JsonFileAbsolutePath ");
                        return;
                    }
                }
                string _countryJson = File.ReadAllText(path);
                var _country = JsonConvert.DeserializeObject<List<IndiaCity>>(_countryJson);
                var result = from s in _country
                             where s.city.ToUpper() == cityName.Trim().ToUpper()
                             select s;
                if (result.Count() == 0)
                {
                    Console.WriteLine("Enter City  :" + cityName + " not present in Database");
                    return;
                }
                string latitude = result.FirstOrDefault().lat;
                string longitude = result.FirstOrDefault().lng;
                string apiPath = String.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true",
                                      latitude, longitude);
                // Get the Weather Information async
                product = await GetWeatherInfoAsync(apiPath);
                Console.WriteLine("Temperature :" + product.current_weather.temperature);
                Console.WriteLine("Winddirection :" + product.current_weather.winddirection);
                Console.WriteLine("windspeed :" + product.current_weather.windspeed);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
        static async Task<WeatherInformation> GetWeatherInfoAsync(string path)
        {
            WeatherInformation product = new WeatherInformation();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<WeatherInformation>();

            }
            return product;
        }

    }

}
