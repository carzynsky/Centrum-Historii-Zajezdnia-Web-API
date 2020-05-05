using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Models;
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
        public async Task<ActionResult<Measurement>> GetAllMeasurement()
        {
            var _measurement = await _service.GetAll();
            return Ok(_measurement);
        }

        /// <summary>
        /// Pobranie wszystkich pomiarów dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAllMeasurement([FromRoute]int id)
        {
            var _measurement = await _service.GetAll(id);
            return Ok(_measurement);
        }

        /// <summary>
        /// Pobranie średnich temperatur każdego miesiąca dla czujnika o podanym id
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/averageTemperatureByMonth")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAverageTemperatureByEachMonth([FromRoute] int id)
        {
            var _average = await _service.GetAverageTemperatureByEachMonth(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie średnich temperatur z ostanich 7 dni dla czujnika o podanym id
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/averageTemperatureLastWeek")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAverageTemperatureLastWeek([FromRoute] int id)
        {
            var _average = await _service.GetAverageTemperatureLastWeek(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie średnich temperatur dla ostatnich lat dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}/averageTemperatureLastYears")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAverageTemperatureLastYears([FromRoute] int id)
        {
            var _average = await _service.GetAverageTemperatureLastYears(id);
            return Ok(_average);
        }


        /// <summary>
        /// Pobranie średnich wilgotności powietrza każdego miesiąca aktualnego roku dla czujnika o podanym
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}/averageHumidityByMonth")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAverageHumidityByEachMonth([FromRoute] int id)
        {
            var _average = await _service.GetAverageHumidityByEachMonth(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie średnich wilgotności powietrza z ostanich 7 dni dla czujnika o podanym id
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/averageHumidityLastWeek")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAverageHumidityLastWeek([FromRoute] int id)
        {
            var _average = await _service.GetAverageHumidityLastWeek(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie średnich wilgotności powietrza dla ostatnich lat dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}/averageHumidityLastYears")]
        [HttpGet]
        public async Task<ActionResult<Measurement>> GetAverageHumidityLastYears([FromRoute] int id)
        {
            var _average = await _service.GetAverageHumidityLastYears(id);
            return Ok(_average);
        }

        /// <summary>
        /// Pobranie liczby wszystkich dokonanych pomiarów dla danego czujnika o podanym id
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/numberOfAllMeasurement")]
        [HttpGet]
        public async Task<ActionResult> GetNumberOfAllMeasurement([FromRoute] int id) 
        {
            var _numberOfMeasurement = await _service.GetNumberOfAllMeasurement(id);
            return Ok(_numberOfMeasurement);
        }

        /// <summary>
        /// Pobranie liczby pomiarów wykonanych w tym miesiącu dla danego czujnika o podanym id
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/numberOfMeasurementThisMonth")]
        [HttpGet]
        public async Task<ActionResult> GetNumberOfMeasurementThisMonth([FromRoute] int id)
        {
            var _numberOfMeasurementThisMonth = await _service.GetNumberOfMeasurementThisMonth(id);
            return Ok(_numberOfMeasurementThisMonth);
        }

        /// <summary>
        /// Pobranie liczby pomiarów wykonanych w tym miesiącu dla danego czujnika określonego w routingu
        /// </summary>
        /// <returns></returns>
        [Route("{id:int}/numberOfMeasurementToday")]
        [HttpGet]
        public async Task<ActionResult> GetNumberOfMeasurementToday([FromRoute] int id)
        {
            var _numberOfMeasurementToday = await _service.GetNumberOfMeasurementToday(id);
            return Ok(_numberOfMeasurementToday);
        }

        /// <summary>
        /// Pobranie informacji o ostatnich pomiarach dla wszystkich czujników
        /// </summary>
        /// <returns></returns>
        [Route("last")]
        [HttpGet]
        public async Task<ActionResult<SensorInfo>> GetLastMeasurement()
        {
            var _last = await _service.GetLastMeasurement();
            return Ok(_last);
        }

        /// <summary>
        /// Pobranie informacji p pomiarach do rocznego raportu dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}/report")]
        [HttpGet]
        public async Task<ActionResult<List<float>>> GetInformationForReport([FromRoute] int id)
        {
            var _info = await _service.GetInformationForReport(id);
            return Ok(_info);
        }
    }
}