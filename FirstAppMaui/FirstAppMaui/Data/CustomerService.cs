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
    public class CustomerService
    {
        private readonly RestClient _client;

        public CustomerService()
        {
            //_client = new RestClient("http://10.0.2.2:5057/");
            _client = new RestClient("http://localhost:5057/");
        }

        public async Task<List<Customer>> GetCustomers()
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/customers");

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Customer>>(response.Content);
            }

            return null;
        }

        public async Task<CustomerViewModel> GetCustomerById(string customerId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/customers/" + customerId);

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<CustomerViewModel>(response.Content);
            }

            return null;
        }

        public async Task<bool> UpdateCustomer(string customerId, Customer customer)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/customers/" + customerId);

            request.AddBody(customer);

            var response = await _client.PutAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCustomer(string customerId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/customers/" + customerId);

            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }
    }
}
