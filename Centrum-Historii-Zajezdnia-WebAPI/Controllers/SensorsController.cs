using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Centrum_Historii_Zajezdnia_WebAPI.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/sensors")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        ISensorsService _service;
        public SensorsController(ISensorsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllSensors()
        {
            var _sensors = _service.GetAllSensors();
            return Ok(_sensors);
        }
    }
}