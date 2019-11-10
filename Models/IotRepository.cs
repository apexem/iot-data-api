using System;
using System.Collections.Generic;
using System.Linq;

namespace sql_berry_api.Models
{
    public class IotRepository
    {
        private MeasurementsContext ctx = new MeasurementsContext();

        public void AddNewTemperature(TemperatureMea mea)
        {
            ctx.Temperatures.Add(mea);
            ctx.SaveChanges();
        }

        public IEnumerable<TemperatureMea> GetAllTemp()
        {
            return ctx.Temperatures.ToList();
        }
    }
}
