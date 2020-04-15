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
    [Route("api/measurement")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        IMeasurementService _service;

        /// <summary>
        /// Constructor of MeasurementController class
        /// </summary>
        /// <param name="service"></param>
        public MeasurementController(IMeasurementService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all measurement from database - only for testing
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllMeasurement()
        {
            var _measurement = _service.GetAll();
            return Ok(_measurement);
        }

        /// <summary>
        /// Pobranie średnich temperatur dla każdego miesiąca
        /// </summary>
        /// <returns></returns>
        [Route("averageByMonth")]
        [HttpGet]
        public IActionResult GetAverageTemperatureByEachMonth()
        {
            var _average = _service.GetAverageTemperatureByEachMonth();
            return Ok(_average);
        }
    }
}