using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace sql_berry_api.Services
{
    public class DhtService : IDhtService
    {
        private readonly string _dhtIp;
        private readonly HttpClient _httpClient;
        public DhtService(HttpClient client)
        {
            _httpClient = client;
            _dhtIp = "123";
        }

        public async Task<string> GetTemperature()
        {
            var tempGetUri = _dhtIp + "/temperature";
            var response = await _httpClient.GetStringAsync(tempGetUri);
            return response;
        }

        public async Task<string> GetHumidity()
        {
            var tempGetUri = _dhtIp + "/humidity";
            var response = await _httpClient.GetStringAsync(tempGetUri);
            return response;
        }
    }
}
