using Common.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppMaui.Data
{
    public class RMaintenanceService
    {
        private readonly RestClient _client;

        public RMaintenanceService()
        {
            //_client = new RestClient("http://10.0.2.2:5057/");
            _client = new RestClient("http://localhost:5057/");
        }

        public async Task<List<ReservationService>> GetRMServices(string reservationId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/ReservationServices/getbyreservationid?reservationId=" + reservationId);

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<ReservationService>>(response.Content);
            }

            return null;
        }

        public async Task<bool> CreateRMService(ReservationService reservationService)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/ReservationServices");

            request.AddBody(reservationService);

            var response = await _client.PostAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteRMService(ReservationService reservationService)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/ReservationServices/deletebyrm?reservationId=" + reservationService.ReservationId +
                "&mserviceId=" + reservationService.MaintenanceServiceId);

            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }
    }
}
