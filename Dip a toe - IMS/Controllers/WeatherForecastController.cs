using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Dip_a_toe___IMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List<WeatherForecast> forecasts = new List<WeatherForecast>();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get(int range = 5)
        {
            if (range < 0)
                return BadRequest(new List<WeatherForecast>());

            var rng = new Random();
            return Enumerable.Range(1, range).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Summaries")]
        public ActionResult<string[]> GetSummaries()
        {
            return Summaries;
        }

        [HttpGet("Forecasts")]
        public ActionResult<List<WeatherForecast>> GetAll()
        {
            return forecasts;
        }

        [HttpPost]
        public ActionResult Post(WeatherForecast forecast)
        {
            forecasts.Add(forecast);
            return Ok("Alles in de sjakos");
        }

        /*[HttpGet("{range}")]
        public IEnumerable<WeatherForecast> Get(int range=5)
        {
            var rng = new Random();

            //WeatherForecast[] array = new WeatherForecast[5];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = new WeatherForecast(DateTime.Now.AddDays(i), rng.Next(-20, 55), Summaries[rng.Next(Summaries.Length)])
            //}
            return Enumerable.Range(1, range).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
        /*
        [AcceptVerbs("Post","Put")]
        public IEnumerable<WeatherForecast> Post()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
    }
}
