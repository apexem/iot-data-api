
namespace sql_berry_api.Models
{
    public abstract class ESPJson
    {
        public string id { get; set; }
        public string name { get; set; }
        public string hardware { get; set; }
        public bool connected { get; set; }
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