
namespace sql_berry_api.Models
{
    public abstract class ESPJson
    {
        public string module { get; set; } 
    }

    public class TemperatureJson : ESPJson
    {
        public float temperature { get; set; }
    }

    public class AnalogJson : ESPJson
    {
        public int analog { get; set; }
    }
}