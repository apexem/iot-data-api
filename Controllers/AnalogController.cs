using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sql_berry_api.Models;
using sql_berry_api.Services;
using System.Text.Json;

namespace sql_berry_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalogController : ControllerBase
    {
        private IotRepository _repo = new IotRepository();
        private readonly IDhtService _dhtService;
        public AnalogController(IDhtService dhtService) => _dhtService = dhtService;

        [HttpGet]
        public ActionResult<AnalogInput> GetAllAnalog()
        {
            var meas = _repo.GetAnalogInputs();
            return Ok(meas);
        }

        [HttpPost]
        [Route("AddAnalog")]
        public ActionResult AddAnalog([FromBody]AnalogInput analog)
        {
            _repo.AddNewAnalog(analog);
            return Ok();
        }

        [HttpGet]
        [Route("GetCurrentAnalog")]
        public async Task<ActionResult<string>> GetCurrentAnalog()
        {
            var mea = await _dhtService.GetAnalog();
            try
            {
                var values = JsonSerializer.Deserialize<AnalogJson>(mea);
                var now = DateTime.Now;
                var meaObj = new AnalogInput()
                {
                    Date = now.ToString(),
                    ModuleName = values.module,
                    Voltage = values.analog,
                };
                _repo.AddNewAnalog(meaObj);
                return mea;
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}