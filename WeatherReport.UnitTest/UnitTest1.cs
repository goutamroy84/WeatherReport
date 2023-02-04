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
    }
}
