using System;
using WeatherReport;

namespace WeatherReport.Helper
{
    public static class Helper
    {
        public static string FormAPIPath(string latitude, string longitude)
        {
            //string path = "https://api.open-meteo.com/v1/forecast?latitude=18.9667&longitude=72.8333&current_weather=true";
            latitude = "18.9667";
            longitude = "72.8333";
            string apiPath = String.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&current_weather=true",
                                  latitude, longitude);
            return apiPath;
        }

        //public static void TestRun(string cityName)
        //{
        //    string CityName = Console.ReadLine();
        //    Program.RunAsync(CityName).GetAwaiter().GetResult();
        //}
    }
}
