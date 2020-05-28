using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Centrum_Historii_Zajezdnia_WebAPI.Controllers
{
    [EnableCors("AllowLocalOrigin")]
    //[Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsersService _service;
        public UsersController(IUsersService service)
        {
            _service = service;
        }

        /// <summary>
        /// Pobranie wszystkich użytkowników wraz z ich funkcjami
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<Users>>> Get()
        {
            var users = await _service.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Logowanie do systemu
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public async Task<Response> Login([FromBody] Users user)
        {
            var _info = await _service.UserSignin(user);
            return _info;
        }

        /// <summary>
        /// Edycja użytkownika
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] Users user, [FromRoute] int id)
        {
            var isEdited = await _service.IsUpdateSuccessfull(id, user);
            if(isEdited)
            {
                return NoContent();
            }
            else
            {
                return Conflict("Couldn't update!");
            }
        }

        /// <summary>
        /// Usunięcie użytkownika o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _service.IsDeleteSuccessfull(id);
            if(isDeleted)
            {
                return Ok();
            }
            else
            {
                return Conflict("Nie można usunąć!");
            }
        }

        /// <summary>
        /// Dodanie użytkownika do bazy
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Response> CreateNewUser([FromBody] Users user)
        {
            var isCreated = await _service.IsCreateSuccessfull(user);
            if(isCreated)
            {
                return new Response {Status="Success", Message="Dodano użytkownika!", Function=null} ;
            }
            else
            {
                return new Response { Status = "Error", Message = "Już istnieje uzytkownik o tym loginie!", Function = null };
            }
        }

        /// <summary>
        /// Pobranie wszystkich możliwych ról użytkowników
        /// </summary>
        /// <returns></returns>
        [Route("functions")]
        [HttpGet]
        public async Task<ActionResult<UserFunction>> GetUserFunctions()
        {
            var functions = await _service.GetAllFunctions();
            return Ok(functions);
            
        }
    }
}