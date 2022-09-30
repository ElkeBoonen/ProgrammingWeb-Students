using Microsoft.AspNetCore.Mvc;
using System;

namespace Dip_a_toe___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        static List<WeatherForecast> forecasts = new List<WeatherForecast>();
        static int counter = 0;


        [HttpGet("Summaries")]
        public string[] GetSummaries()
        {
            return Summaries;
        }

        [HttpGet("Stored")]
        public List<WeatherForecast> GetStoredForecasts()
        {
            return forecasts;
        }

        [HttpPost("Count")]
        public int Post()
        {
            counter++;
            return counter;
        }

        [HttpPost]
        public ActionResult Post(WeatherForecast forecast)
        {
            forecasts.Add(forecast);
            return Ok("Post was ok!");
        }

        //[HttpGet("{range}")]
        //[AcceptVerbs("GET", "POST")]
       [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get(int range=5)
        {
            try
            {
                //if (range < 0) return BadRequest("Check your range!");

                WeatherForecast[] forecasts = new WeatherForecast[range];
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
            }
            catch (OverflowException)
            {
                return BadRequest("Check your range!");
            }
            catch
            {
                return BadRequest("Whoopsie! Try again!");
            }
            /*return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();*/
        }

        /*[HttpPost]
        public IEnumerable<WeatherForecast> PostMethodThatIsAGetMethod()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
    }
}