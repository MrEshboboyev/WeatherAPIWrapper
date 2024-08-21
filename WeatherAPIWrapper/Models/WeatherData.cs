namespace WeatherAPIWrapper.Models
{
    public class WeatherData
    {
        public string Address { get; set; }
        public string TimeZone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public DayData TodayWeather { get; set; }
    }

    public class DayData
    {
        public string DateTime { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string Conditions { get; set; }
    }

}
