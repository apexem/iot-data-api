using System;
namespace sql_berry_api.Models
{
    public abstract class Measurement
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string ModuleName { get; set; }
    }
}
