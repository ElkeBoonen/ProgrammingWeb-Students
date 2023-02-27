using Microsoft.AspNetCore.Mvc;

namespace Hello_API___IMS.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static List<WeatherForecast> list = new List<WeatherForecast>();

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /*[HttpPost]
        public IEnumerable<WeatherForecast> Blablablabla()
        {
            _logger.Log(LogLevel.Information, "GetWeatherForecast called");
         
        }*/

        [HttpPost]
        public ActionResult Post(WeatherForecast forecast)
        {
            list.Add(forecast);
            return Ok("Forecast added");
        }

        [HttpGet]
        [Route("LIST")]
        public ActionResult<List<WeatherForecast>> GetList()
        {
            return Ok(list);
        }

        //[HttpGet("{range}")]  //maakt er een uri parameter van
        [HttpGet]               //is query parameter
        public ActionResult<IEnumerable<WeatherForecast>> Get(int range=5)
        {
            //mogelijke actionresults: https://nl.wikipedia.org/wiki/Lijst_van_HTTP-statuscodes
            _logger.Log(LogLevel.Information, "GetWeatherForecast called");

            if (range < 0) return BadRequest("Range must be positive");

            return Ok(Enumerable.Range(1, range).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());

            /* HIER DOEN WE NET HETZELFDE
             
            WeatherForecast[] forecasts = new WeatherForecast[5];
            for (int i = 0; i < forecasts.Length; i++)
            {
                forecasts[i] = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            }
            return forecasts;
             
             
             */

        }
    }
}