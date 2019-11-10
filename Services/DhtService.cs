using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sql_berry_api.Services
{
    public class DhtService : IDhtService
    {
        private readonly string _address;
        private readonly HttpClient _httpClient;
        public DhtService(HttpClient client)
        {
            _httpClient = client;
            _address = "http://192.168.100.31";
        }

        public async Task<string> GetTemperature()
        {
            var tempGetUri = _address + "/temperature";
            var response = await _httpClient.GetStringAsync(tempGetUri);
            return response;
        }

        public async Task<string> GetAnalog()
        {
            var tempGetUri = _address + "/analog";
            var response = await _httpClient.GetStringAsync(tempGetUri);
            return response;
        }

        public async Task<string> GetHumidity()
        {
            var tempGetUri = _address + "/humidity";
            var response = await _httpClient.GetStringAsync(tempGetUri);
            return response;
        }
    }
}
