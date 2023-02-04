using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReport;
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

        }
        
        [TestMethod]
        public void IsCityFileexists()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CityInformation\IndiaCity.json");
            bool isequal = File.Exists(path);
            Assert.IsTrue(isequal);
        }     
    }
}
