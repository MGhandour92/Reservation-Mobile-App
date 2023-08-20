using Common;
using Common.ViewModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FirstAppMaui.Data
{
	public class UserService
	{
		private readonly RestClient _client;

		public UserService()
		{
			//_client = new RestClient("http://10.0.2.2:5057/");
			_client = new RestClient("http://localhost:5057/");
		}

		public async Task<bool> Login(LoginViewModel loginViewModel)
		{
			//Call Endpoint - API 
			var request = new RestRequest("api/customers/login");

			request.AddBody(loginViewModel);

			var response = await _client.ExecutePostAsync(request);

			return response.IsSuccessful;
		}

		public async Task<bool> Register(CustomerViewModel customerViewModel)
		{
			//Call Endpoint - API 
			var request = new RestRequest("api/customers/register");

			request.AddBody(customerViewModel);

			var response = await _client.ExecutePostAsync(request);

			return response.IsSuccessful;
		}
	}
}
