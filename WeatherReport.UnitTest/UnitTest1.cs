using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WeatherReport.Model;

namespace WeatherReport.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleAsync()
        {

            Program pro = new Program();
            string[] city = { "Kolkata", "Delhi" };
            Program.Run(city);
             Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void IsCityFileexists()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CityInformation\IndiaCity.json");
            bool isequal = File.Exists(path);
            Assert.IsTrue(isequal);
        } 
        
        [TestMethod]
        public void CityPresentInJson()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CityInformation\IndiaCity.json");
            string _countryJson = File.ReadAllText(path);
            var _country = JsonConvert.DeserializeObject<List<IndiaCity>>(_countryJson);
            int i = 0;
            foreach (var item in _country)
            {
                i++;
                var result = from s in _country
                             where s.city == item.city
                             select s;
            }
            Assert.IsTrue(i > 0);

        }
        
    }
}
