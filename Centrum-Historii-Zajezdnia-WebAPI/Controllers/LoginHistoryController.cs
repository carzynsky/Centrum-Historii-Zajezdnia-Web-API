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
    [Route("api/loginHistory")]
    [ApiController]
    public class LoginHistoryController : ControllerBase
    {
        ILoginHistoryService _service;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="service"></param>
        public LoginHistoryController(ILoginHistoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Pobranie całej historii logowań
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<LoginHistory>>> GetAllHistory()
        {
            var _loginHistory = await _service.GetAllWithUsers();
            return Ok(_loginHistory);
        }

        /// <summary>
        /// Pobranie logowań dla użytkownika o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<List<LoginHistory>>> GetHistoryByUserId([FromRoute] int id)
        {
            var history = await _service.GetByUserId(id);
            return Ok(history);
        }

        /// <summary>
        /// Usunięcie całej historii logowań
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteAllHistory()
        {
            await _service.DeleteHistory();
            return Ok();
        }

        
    }
}