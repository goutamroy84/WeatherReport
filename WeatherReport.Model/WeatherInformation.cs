namespace WeatherReport.Model
{
    public class WeatherInformation
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string generationtime_ms { get; set; }
        public string utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public string elevation { get; set; }
        public WeatherForecast current_weather { get; set; }
    }
}
