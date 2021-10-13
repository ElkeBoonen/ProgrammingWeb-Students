using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dip_a_toe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        static private int count = 0;
        static private WeatherForecast[] forecast = new WeatherForecast[30];

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            var rng = new Random();
            for (int i = 0; i < forecast.Length; i++)
            {
                forecast[i] = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            }

        }

        [HttpPost]
        public ActionResult<int> Post()
        {
            return Ok(++count);
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            return forecast;
        }


        //[AcceptVerbs("GET")]
        [HttpGet("{index}")]
        public ActionResult<WeatherForecast> Get(int index = 5)
        {
            //return day 5 or day 6 or day 7 or...
            if (index < 0 && index > 30) return BadRequest();

            _logger.Log(LogLevel.Information, "TEST LOGGER");



            /*return Ok(Enumerable.Range(1, range).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());*/

            return forecast[index];

        }
    }
}
