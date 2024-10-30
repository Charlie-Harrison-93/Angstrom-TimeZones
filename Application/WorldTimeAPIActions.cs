using Application;
using Application.Controller;
using System.Globalization;
using System.Net.Http.Json;

namespace Application.Actions
{
    public class WorldTimeAPIActions
    {
        private readonly WorldTimeAPIController _worldTimeAPIController = new WorldTimeAPIController();


        public DateTimeOffset GetDateTimeFromWorldTimeTimeZoneAction(string country, string city)
        {
            var response = _worldTimeAPIController.WorldTimeTimeZoneController(country, city);

            return DateTimeOffset.ParseExact(response.datetime, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFzzz", CultureInfo.InvariantCulture);
        }
    }
}



