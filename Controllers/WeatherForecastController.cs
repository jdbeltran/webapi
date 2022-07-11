using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>(); 

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    // [Route("Get/weatherForecast")]
    //   [Route("Get/weatherForecast2")]
    //   [Route("[action]")]
    public IEnumerable<WeatherForecast> GetW()
    {
        _logger.LogDebug("Retornando la lista de WeatherForecast");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast model){
        ListWeatherForecast.Add(model);
        return Ok(); 
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index){
        ListWeatherForecast.RemoveAt(index);
        return Ok(); 
    }
    
}
