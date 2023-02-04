using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherReport.Model;

namespace WeatherReport.BusinessLogic
{
    public class Report
    {
        static HttpClient client = new HttpClient();
        static async Task<WeatherInformation> GetProductAsync(string path)
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
