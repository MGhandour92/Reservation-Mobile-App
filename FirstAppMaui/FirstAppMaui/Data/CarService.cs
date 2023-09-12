using Common.Entities;
using Common.ViewModel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppMaui.Data
{
    public class CarService
    {
        private readonly RestClient _client;

        public CarService()
        {
            //_client = new RestClient("http://10.0.2.2:5057/");
            _client = new RestClient("http://localhost:5057/");
        }

        public async Task<CustomerCarViewModel> GetCarById(string carId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/cars/" + carId);

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<CustomerCarViewModel>(response.Content);
            }

            return null;
        }
        public async Task<List<Car>> GetCustomerCarsByCustomerId(string customerId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/cars?customerId=" + customerId);

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Car>>(response.Content);
            }

            return null;
        }

        public async Task<bool> CreateCar(Car car)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/cars");

            request.AddBody(car);

            var response = await _client.PostAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCar(string carId, Car car)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/cars/" + carId);

            request.AddBody(car);

            var response = await _client.PutAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCar(string carId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/cars/" + carId);

            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }
    }
}
