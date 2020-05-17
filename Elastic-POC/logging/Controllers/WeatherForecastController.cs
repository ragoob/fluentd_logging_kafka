using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.Kafka;

namespace logging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherForecastController()
        {
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            Log.Information("data feached from WeatherForecast api " + DateTime.Now.ToString());
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            
        }

         [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

         string brokers = "192.168.1.6:9092";
            string topic = "log_excptions";
           var Logger  = new LoggerConfiguration()
             .WriteTo.Kafka(brokers,50,5,topic:topic)
             .CreateLogger();

            try
            {
                throwExc();
            }
            catch (System.Exception ex)
            {
                
                 Logger.Error(ex.StackTrace);
            
            }
          
           
           return Ok("Done");
            
        }

        private void throwExc(){
            throw new NullReferenceException("null Reference Exception");
        }
    }
}
