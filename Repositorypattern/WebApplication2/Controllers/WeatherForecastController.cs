using Microsoft.AspNetCore.Mvc;
using Repositorypattern.Services.Implemantation;
using Repositorypattern.Services.Interface;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherforecastService _WeatherforecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IWeatherforecastService WeatherforecastService)
        {
            _logger = logger;
            _WeatherforecastService = WeatherforecastService;

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _WeatherforecastService.Get();
        }
    }
}
