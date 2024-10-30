using Application;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly Helpers _helpers;
        private readonly CountryDateTimeModel _countryDateTimeModel;

        public Tests()
        {
            _helpers = new Helpers();
            _countryDateTimeModel = new CountryDateTimeModel();
        }

        [TestMethod]
        public void mustDisplayTheCurrentTimeForTheUK()
        {
            // create data object for UK 
            CountryDateTimeModel UKDetails = new CountryDateTimeModel
            {
                country = "Europe",
                city = "London",
                dateTimeFormat = "dddd dd MMMM yyyy HH:mm:ss"
            };

            var UKDateTimeDetails = _helpers.GetCurrentDateTimeForCountryAndCity(UKDetails);

            // testing the format is as expected
            Assert.IsTrue(UKDateTimeDetails.cityDateTimeString.Contains(UKDateTimeDetails.cityDateTime.ToString("dddd dd MMMM yyyy HH:mm:ss")));

            // testing the date value is correct
            Assert.IsTrue(UKDateTimeDetails.cityDateTime.ToString("dddd dd MMMM yyyy HH").Equals(DateTime.Now.ToString("dddd dd MMMM yyyy HH")));
        }

        [TestMethod]
        public void mustDisplayTheCurrentTimeForCanida()
        {
            // create data object for Canida 
            CountryDateTimeModel canidaDetails = new CountryDateTimeModel
            {
                country = "America",
                city = "Toronto",
                dateTimeFormat = "dddd dd MMMM yyyy HH:mm:ss"
            };

            var canidaDateTimeDetails = _helpers.GetCurrentDateTimeForCountryAndCity(canidaDetails);

            // testing the format is as expected
            Assert.IsTrue(canidaDateTimeDetails.cityDateTimeString.Contains(canidaDateTimeDetails.cityDateTime.ToString("dddd dd MMMM yyyy HH:mm:ss")));

            // testing the date value is correct
            Assert.IsTrue(canidaDateTimeDetails.cityDateTime.ToString("dddd dd MMMM yyyy HH").Equals(DateTime.Now.AddHours(-5).ToString("dddd dd MMMM yyyy HH")));
        }

        [TestMethod]
        public void CompareTheUKAndCanidaDates()
        {
            // create data object for UK 
            CountryDateTimeModel UKDetails = new CountryDateTimeModel
            {
                country = "Europe",
                city = "London",
                dateTimeFormat = "dddd dd MMMM yyyy HH:mm:ss"
            };

            // create data object for Canida 
            CountryDateTimeModel canidaDetails = new CountryDateTimeModel
            {
                country = "America",
                city = "Toronto",
                dateTimeFormat = "dddd dd MMMM yyyy HH:mm:ss"
            };

            string comparisionDetails = _helpers.CompareTimeZones(UKDetails, canidaDetails);

            Assert.IsTrue(comparisionDetails.Contains("5 hours"));
        }
    }
}