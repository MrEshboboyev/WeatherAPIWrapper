namespace WeatherAPIWrapper.Models
{
    public class WeatherData
    {
        public string Location { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }
        public double Humidity { get; set; }
    }
}
