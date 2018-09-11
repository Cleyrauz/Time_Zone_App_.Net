using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timezone;

namespace TimezoneTest
{
    [TestClass]
    public class ParserTest
    {

        [TestMethod]
        public void CanGetTimeZoneByCity()
        {
            Parser parser = new Parser();
            string goodCityName = "London";
            Assert.IsNotNull(parser.GetTimeZoneFromCity(goodCityName));
        }


        [TestMethod]
        public void CanNotGetTimeZoneByCity()
        {
            Parser parser = new Parser();
            string badCityName = "BadCityName";
            Assert.IsNull(parser.GetTimeZoneFromCity(badCityName));
        }

        [TestMethod]
        public void CanConvertTimeZoneFromCity()
        {
            Parser parser = new Parser();
            string goodCityName = "Amsterdam";
            string localCityName = "London";
            DateTime dateTime = Convert.ToDateTime("00:00");
            Assert.IsNotNull(parser.ConvertTimeFromTimeZone(dateTime, localCityName, goodCityName));
        }


        [TestMethod][ExpectedException(typeof(ArgumentNullException))]
        public void CanNotConvertTimeZoneFromCity()
        {
            Parser parser = new Parser();
            string badCityName = null;
            string localCityName = "London";
            DateTime dateTime = Convert.ToDateTime("00:00");
            parser.ConvertTimeFromTimeZone(dateTime, localCityName, badCityName);
        }

    }

}
