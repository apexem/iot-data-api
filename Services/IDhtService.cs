using System.Threading.Tasks;

namespace sql_berry_api.Services
{
    public interface IDhtService
    {
        Task<string> GetTemperature();
        Task<string> GetHumidity();
    }
}