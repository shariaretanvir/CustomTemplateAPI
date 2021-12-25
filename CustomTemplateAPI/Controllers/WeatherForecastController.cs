using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTemplateAPI.Controllers
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
        private readonly IMemoryCache memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IMemoryCache memoryCache)
        {
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet,Route("getall")]
        public async Task<IActionResult> Getall()
        {
            var cacheKey = "weather";
            if(!memoryCache.TryGetValue(cacheKey,out List<WeatherForecast> weathers))
            {
                weathers = new List<WeatherForecast> {
                    new WeatherForecast
                    {
                        Summary= "1"
                    },
                    new WeatherForecast
                    {
                        Summary= "2"
                    },
                    new WeatherForecast
                    {
                        Summary= "3"
                    }
                };
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(10),
                    Priority = CacheItemPriority.Normal,
                    SlidingExpiration = TimeSpan.FromSeconds(10)
                };
                memoryCache.Set(cacheKey, weathers, cacheOptions);

                await Task.Delay(3000);                
            }
            

            return Ok(weathers);
        }
    }
}
