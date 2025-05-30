using Repositorypattern.Services.Interface;
using WebApplication2;

namespace Repositorypattern.Services.Implemantation
{
    public class WeatherForecastserviceextended : IWeatherforecastService
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        IEnumerable<WeatherForecast> IWeatherforecastService.Get()
        {
            return Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
