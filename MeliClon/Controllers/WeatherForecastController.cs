using Microsoft.AspNetCore.Mvc;

namespace MeliClon.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> products = new List<WeatherForecast>();
            products.Add(new WeatherForecast()
            {
                Id = 1,
                Name = "producto uno"
            });
            products.Add(new WeatherForecast() 
            { 
                Id = 2, 
                Name = "producto 2" 
            });

            return products;
        }
    }
}