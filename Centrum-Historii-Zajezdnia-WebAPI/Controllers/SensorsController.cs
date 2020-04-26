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
    [Route("api/sensors")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        ISensorsService _service;
        public SensorsController(ISensorsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Pobranie wszystkich czujników z bazy
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Sensors>> GetAllSensors()
        {
            var _sensors = await _service.GetAllSensors();
            return Ok(_sensors);
        }

        /// <summary>
        /// Dodanie czujnika do bazy
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateSensor([FromBody] Sensors sensor)
        {
            var isCreateSuccessfull = await _service.CreateSensor(sensor);
            if(isCreateSuccessfull)
            {
                return Ok();
            }
            else
            {
                return Conflict();
            }
        }

        /// <summary>
        /// Edycja czujnika o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sensor"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpPut]
        public async Task<ActionResult> EditSensor([FromRoute] int id, [FromBody] Sensors sensor)
        {
            var isEditSuccessfull = await _service.EditSensor(id, sensor);

            if(isEditSuccessfull)
            {
                return Ok("Sensor has been successfully edited!");
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Usunięcie czujnika z bazy o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSensor([FromRoute] int id)
        {
            var isDeleteSuccessfull = await _service.DeleteSensor(id);
            if (isDeleteSuccessfull)
            {
                return Ok("Sensor has been successfully created!");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}