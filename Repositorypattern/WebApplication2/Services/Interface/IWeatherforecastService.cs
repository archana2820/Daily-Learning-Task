using WebApplication2;

namespace Repositorypattern.Services.Interface
{
    public interface IWeatherforecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
