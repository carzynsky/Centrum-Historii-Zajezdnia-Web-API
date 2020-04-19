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
        /// Pobranie wszystkich pomiarów
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllMeasurement()
        {
            var _measurement = _service.GetAll();
            return Ok(_measurement);
        }

        /// <summary>
        /// Pobranie średnich temperatur każdego miesiąca dla czujnika określonego w routingu
        /// </summary>
        /// <returns></returns>
        [Route("averageTemperatureByMonth/{id:int}")]
        [HttpGet]
        public IActionResult GetAverageTemperatureByEachMonth([FromRoute] int id)
        {
            var _average = _service.GetAverageTemperatureByEachMonth(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie średnich wilgotności powietrza każdego miesiąca w 2020 roku dla czujnika określonego w routingu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("averageHumidityByMonth/{id:int}")]
        [HttpGet]
        public IActionResult GetAverageHumidityByEachMonth([FromRoute] int id)
        {
            var _average = _service.GetAverageHumidityByEachMonth(id);
            return Ok(_average);
        }

        /// <summary>
        /// Metoda zwraca liczbę wszystkich pomiarów
        /// </summary>
        /// <returns></returns>
        [Route("numberOfAllMeasurement")]
        [HttpGet]
        public IActionResult GetNumberOfAllMeasurement() 
        {
            var _numberOfMeasurement = _service.GetNumberOfAllMeasurement();
            return Ok(_numberOfMeasurement);
        }
    }
}