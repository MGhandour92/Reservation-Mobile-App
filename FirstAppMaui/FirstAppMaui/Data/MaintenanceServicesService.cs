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
    public class MaintenanceServicesService
    {
        private readonly RestClient _client;

        public MaintenanceServicesService()
        {
            //_client = new RestClient("http://10.0.2.2:5057/");
            _client = new RestClient("http://localhost:5057/");
        }

        public async Task<List<MaintenanceService>> GetMServices()
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/MaintenanceServices");

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<MaintenanceService>>(response.Content);
            }

            return null;
        }

        public async Task<List<MaintenanceServiceVM>> GetMServicesWFlags()
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/MaintenanceServices");

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<MaintenanceServiceVM>>(response.Content);
            }

            return null;
        }

        public async Task<MaintenanceService> GetMServiceById(string mServiceId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/MaintenanceServices/" + mServiceId);

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<MaintenanceService>(response.Content);
            }

            return null;
        }

        public async Task<bool> CreateMaintenance(MaintenanceService maintenanceService)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/MaintenanceServices");

            request.AddBody(maintenanceService);

            var response = await _client.PostAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateMService(string mServiceId, MaintenanceService maintenanceService)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/MaintenanceServices/" + mServiceId);

            request.AddBody(maintenanceService);

            var response = await _client.PutAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteMService(string mServiceId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/MaintenanceServices/" + mServiceId);

            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }
    }
}
