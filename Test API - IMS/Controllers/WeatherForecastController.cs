using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static int count = 0;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

     

        [HttpGet] //("{range}")
        public ActionResult<IEnumerable<WeatherForecast>> Get(int range = 5)
        {
            _logger.Log(LogLevel.Information, "het is hier van GET!");
            if (range <= 0) return BadRequest("Range must be non-negative!");

            var rng = new Random();

            WeatherForecast[] forecast = new WeatherForecast[range];
            for (int i = 0; i < forecast.Length; i++)
            {

                forecast[i] = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            }
            return Ok(forecast);
            /*
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }

        [HttpPost]
        public ActionResult<int> Post()
        {
            return ++count;
        }
    }
}
