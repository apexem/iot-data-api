using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sql_berry_api.Models;
using sql_berry_api.Services;
using System.Text.Json;

namespace sql_berry_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private IotRepository _repo = new IotRepository();
        private readonly IDhtService _dhtService;
        public TemperatureController(IDhtService dhtService) => _dhtService = dhtService;

        [HttpGet]
        [Route("xd")]
        public ActionResult<TemperatureMea> TestResponse()
        {
            var xd = new TemperatureMea()
            {
                Date = DateTime.Now.ToString(),
                Temperature = (float)18.0,
            };
            return Ok(xd);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TemperatureMea>> GetAllTemp()
        {
            var xd = _repo.GetAllTemp();
            return Ok(xd);
        }

        [HttpGet]
        [Route("GetCurrentTemperature")]
        public async Task<ActionResult<string>> GetCurrentTemperature()
        {
            var mea = await _dhtService.GetTemperature();
            var values = JsonSerializer.Deserialize<Dictionary<string, string>>(mea);
            try
            {
                var meaObj = new TemperatureMea()
                {
                    Date = DateTime.Today.TimeOfDay.ToString(),
                    ModuleName = "main DHT11",
                    Temperature = float.Parse(values["temperature"]),
                };
                _repo.AddNewTemperature(meaObj);
                return mea;
            }
            catch
            {
                return BadRequest(); 
            }
        }
    }
}
