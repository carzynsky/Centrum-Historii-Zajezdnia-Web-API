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

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetAllMeasurement([FromRoute]int id)
        {
            var _measurement = _service.GetAll(id);
            return Ok(_measurement);
        }

        /// <summary>
        /// Pobranie średnich temperatur każdego miesiąca dla czujnika określonego w routingu
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/averageTemperatureByMonth")]
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
        [Route("{id:int}/averageHumidityByMonth")]
        [HttpGet]
        public IActionResult GetAverageHumidityByEachMonth([FromRoute] int id)
        {
            var _average = _service.GetAverageHumidityByEachMonth(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie liczby wszystkich dokonanych pomiarów dla danego czujnika określonego w routingu
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/numberOfAllMeasurement")]
        [HttpGet]
        public IActionResult GetNumberOfAllMeasurement([FromRoute] int id) 
        {
            var _numberOfMeasurement = _service.GetNumberOfAllMeasurement(id);
            return Ok(_numberOfMeasurement);
        }

        /// <summary>
        /// Pobranie liczby pomiarów wykonanych w tym miesiącu dla danego czujnika określonego w routingu
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/numberOfMeasurementThisMonth")]
        [HttpGet]
        public IActionResult GetNumberOfMeasurementThisMonth([FromRoute] int id)
        {
            var _numberOfMeasurementThisMonth = _service.GetNumberOfMeasurementThisMonth(id);
            return Ok(_numberOfMeasurementThisMonth);
        }

        /// <summary>
        /// Pobranie liczby pomiarów wykonanych w tym miesiącu dla danego czujnika określonego w routingu
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/numberOfMeasurementToday")]
        [HttpGet]
        public IActionResult GetNumberOfMeasurementToday([FromRoute] int id)
        {
            var _numberOfMeasurementToday = _service.GetNumberOfMeasurementToday(id);
            return Ok(_numberOfMeasurementToday);
        }
    }
}