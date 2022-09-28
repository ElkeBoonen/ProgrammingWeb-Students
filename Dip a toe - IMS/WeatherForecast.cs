using System;

namespace Dip_a_toe___IMS
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        /*public WeatherForecast(DateTime date, int c, string summary)
        {
            Date = date;
            TemperatureC = c;
            Summary = summary;
        }*/
    }
}
