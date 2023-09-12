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
    public class ReservationsService
    {
        private readonly RestClient _client;

        public ReservationsService()
        {
            //_client = new RestClient("http://10.0.2.2:5057/");
            _client = new RestClient("http://localhost:5057/");
        }

        public async Task<List<Reservation>> GetReservations()
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/Reservations");

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Reservation>>(response.Content);
            }

            return null;
        }

        public async Task<Reservation> GetReservationById(string ReservationId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/Reservations/" + ReservationId);

            var response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Reservation>(response.Content);
            }

            return null;
        }

        public async Task<bool> CreateMaintenance(Reservation reservation)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/Reservations");

            request.AddBody(reservation);

            var response = await _client.PostAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateReservation(string ReservationId, Reservation reservation)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/Reservations/" + ReservationId);

            request.AddBody(reservation);

            var response = await _client.PutAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteReservation(string ReservationId)
        {
            //Call Endpoint - API 
            var request = new RestRequest("api/Reservations/" + ReservationId);

            var response = await _client.DeleteAsync(request);

            if (response.IsSuccessful)
            {
                return true;
            }

            return false;
        }
    }
}
