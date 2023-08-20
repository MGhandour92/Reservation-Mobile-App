using Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class WeatherForecastController : ControllerBase
	{
	//	private static readonly string[] Summaries = new[]
	//	{
	//	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	//};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly MyDBContext _dBContext;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, MyDBContext dBContext)
		{
			_logger = logger;
			_dBContext = dBContext;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<WeatherForecast> Get()
		{
			return _dBContext.WeatherForecasts!.ToArray();

			//return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			//{
			//	ForecastDate = DateTime.Now.AddDays(index),
			//	TemperatureC = Random.Shared.Next(-20, 55),
			//	Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			//})
			//.ToArray();
		}
	}
}