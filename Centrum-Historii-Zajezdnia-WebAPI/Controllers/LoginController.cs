using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Centrum_Historii_Zajezdnia_WebAPI.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        /// <summary>
        /// Constructor of LoginController class
        /// </summary>
        /// <param name="service"></param>
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _service.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Post method that checks whether user logged succesfully
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public Response employeeLogin(Users user)
        {
            var info = _service.UserSignin(user);
            return info;
        }
    }
}