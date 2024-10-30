using Application;
using System.Globalization;
using System.Net.Http.Json;


namespace Application.Controller
{
    public class WorldTimeAPIController
    {
        public WorldTimeAPIResponse WorldTimeTimeZoneController(string country, string city)
        {
            using HttpClient client = new();

            return client.GetFromJsonAsync<WorldTimeAPIResponse>($"http://worldtimeapi.org/api/timezone/{country}/{city}").Result;
        }

    }
}
