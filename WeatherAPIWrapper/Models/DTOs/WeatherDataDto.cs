namespace WeatherAPIWrapper.Models.DTOs
{
    public class WeatherDataDto
    {
        public string Address { get; set; }
        public string Timezone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public List<DayDataDto> Days { get; set; }
    }

    public class DayDataDto
    {
        public string DateTime { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public string Conditions { get; set; }
    }
}
