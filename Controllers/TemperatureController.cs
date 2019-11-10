using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sql_berry_api.Models;
using sql_berry_api.Services;
using System.Text.Json;

namespace sql_berry_api.Controllers
{
    public class DhtAddres
    {
        public string dhtAddress { get; set; }
    }

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
            var now = DateTime.Now;
            var temp = new TemperatureMea()
            {
                Date = now.ToString(),
                Temperature = (float)18.0,
            };
            return Ok(temp);
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
            try
            {
                var now = DateTime.Now;
                var values = JsonSerializer.Deserialize<TemperatureJson>(mea);
                var meaObj = new TemperatureMea()
                {
                    Date = now.ToString(),
                    ModuleName = "main DHT11",
                    Temperature = values.temperature,
                };
                _repo.AddNewTemperature(meaObj);
                return mea;
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("espAddress")]
        public ActionResult SetDhtServiceEndpoint([FromBody]DhtAddres dhtAddress)
        {
            return Ok();
        }
    }
}
