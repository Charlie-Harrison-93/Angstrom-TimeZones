using Application;
using Application.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Helpers
    {

        private readonly WorldTimeAPIActions _worldTimeAPIActions = new WorldTimeAPIActions();

        public CountryDateTimeModel GetCurrentDateTimeForCountryAndCity(CountryDateTimeModel countryDateTimeModel)
        {
            var countryDateTime = _worldTimeAPIActions.GetDateTimeFromWorldTimeTimeZoneAction(countryDateTimeModel.country, countryDateTimeModel.city);
            countryDateTimeModel.cityDateTime = countryDateTime;
            string countryDateTimeText = $"{countryDateTimeModel.city} {countryDateTimeModel.country} Time: {countryDateTime.ToString(countryDateTimeModel.dateTimeFormat)}";
            countryDateTimeModel.cityDateTimeString = countryDateTimeText;
            Console.WriteLine(countryDateTimeText);
            return countryDateTimeModel;
        }

        public string CompareTimeZones(CountryDateTimeModel firstCountryDateTimeModel, CountryDateTimeModel secondCountryDateTimeModel)
        {
            var firstCountryDetails = this.GetCurrentDateTimeForCountryAndCity(firstCountryDateTimeModel);
            var secondCountryDetails = this.GetCurrentDateTimeForCountryAndCity(secondCountryDateTimeModel);
            
            var aheadOrBehind = "behind";
            if (firstCountryDetails.cityDateTime.DateTime > secondCountryDetails.cityDateTime.DateTime)
            {
                aheadOrBehind = "ahead of";
            }

            var differenceInMinutes = Math.Abs(Math.Round(firstCountryDetails.cityDateTime.DateTime.Subtract(secondCountryDetails.cityDateTime.DateTime).TotalHours, 0));

            var comparisionText = $"{firstCountryDetails.city} {firstCountryDetails.country} is " +
                $"{differenceInMinutes} hours {aheadOrBehind} " +
                $"{secondCountryDetails.city} {secondCountryDetails.country}";

            Console.WriteLine(comparisionText);

            return comparisionText;
        }
    }
}
