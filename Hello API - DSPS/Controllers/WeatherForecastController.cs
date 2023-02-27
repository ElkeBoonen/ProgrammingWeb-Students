using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace Hello_API___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List<WeatherForecast> list = new List<WeatherForecast>();
        
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


        [HttpGet("{range}")]
        public ActionResult<IEnumerable<WeatherForecast>> Get(int range=10)
        {
            if (range < 0) return BadRequest("Negative number!");

            WeatherForecast[] array = new WeatherForecast[range];
            for (int i = 0; i < array.Length; i++)
            {
                WeatherForecast forecast = new WeatherForecast();
                forecast.Date = DateTime.Now.AddDays(i);
                forecast.TemperatureC = Random.Shared.Next(-20, 55);
                forecast.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
                array[i] = forecast;
            }
            return Ok(array);

            /*
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();*/
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            WeatherForecast[] array = new WeatherForecast[10];
            for (int i = 0; i < array.Length; i++)
            {
                WeatherForecast forecast = new WeatherForecast();
                forecast.Date = DateTime.Now.AddDays(i);
                forecast.TemperatureC = Random.Shared.Next(-20, 55);
                forecast.Summary = Summaries[Random.Shared.Next(Summaries.Length)];
                array[i] = forecast;
            }
            return array;
        }

        [HttpPost]
        public void Post(WeatherForecast forecast)
        {
            list.Add(forecast);
        }

        [HttpGet]
        [Route("GETLIST")]
        public IEnumerable<WeatherForecast> GetList()
        {
            return list;
        }
    }
}