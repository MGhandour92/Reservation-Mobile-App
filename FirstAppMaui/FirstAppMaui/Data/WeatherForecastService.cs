using Common;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;

namespace FirstAppMaui.Data;

public class WeatherForecastService
{
	private readonly RestClient _client;

	public WeatherForecastService()
	{
		//_client = new RestClient("http://10.0.2.2:5057/");
		_client = new RestClient("http://localhost:5057/");
	}


	//private static readonly string[] Summaries = new[]
	//{
	//	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	//};

	public Task<WeatherForecast[]> GetForecastAsync(/*DateTime startDate*/)
	{
		//Call Endpoint - API 
		var request = new RestRequest("api/WeatherForecast");
		var response = _client.ExecuteGet(request);

		if (response.IsSuccessful)
		{
			var weatherForecasts = JsonSerializer.Deserialize<WeatherForecast[]>(response.Content,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return Task.FromResult(weatherForecasts);
		}
		else
		{
			return null;
		}


		//return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
		//{
		//	Date = startDate.AddDays(index),
		//	TemperatureC = Random.Shared.Next(-20, 55),
		//	Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		//}).ToArray());
	}
}

