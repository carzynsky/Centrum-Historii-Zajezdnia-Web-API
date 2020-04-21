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
        /// Zwracanie wszystkich uzytkownikow w bazie
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var _users = _service.GetAllUsers();
            return Ok(_users);
        }

        /// <summary>
        /// Logowanie do systemu
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public Response Login(Users user)
        {
            var _info = _service.UserSignin(user);
            return _info;
        }

        /// <summary>
        /// Edytowanie użytkowników 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult Edit([FromBody] Users user, [FromRoute] int id)
        {
            var info = _service.IsUpdateSuccessfull(id, user);
            if(info)
            {
                return NoContent();
            }
            else
            {
                return Conflict("Couldn't update!");
            }
        }

        /// <summary>
        /// Funkcja usuwająca użytkownika z bazy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] int id)
        {
            var info = _service.IsDeleteSuccessfull(id);
            if(info)
            {
                return Ok();
            }
            else
            {
                return Conflict("Couldn't delete!");
            }
        }

        /// <summary>
        /// Dodanie użytkownika do bazy
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNewUser([FromBody] Users user)
        {
            _service.CreateUser(user);
            return Ok();
        }
    }
}