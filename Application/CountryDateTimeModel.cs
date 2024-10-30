namespace Application
{
    public class CountryDateTimeModel
    {
        public string country { get; set; }
        public string city { get; set; }
        public string dateTimeFormat { get; set; }
        public DateTimeOffset cityDateTime { get; set; }
        public string cityDateTimeString { get; set; }
    }
}
