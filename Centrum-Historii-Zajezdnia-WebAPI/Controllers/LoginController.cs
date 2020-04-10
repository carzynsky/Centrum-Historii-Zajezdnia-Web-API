using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Centrum_Historii_Zajezdnia_WebAPI.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _service.Get();
            return Ok(users);
        }
        [HttpPost]
        public Response employeeLogin(Users user)
        {
            var info = _service.SigningIn(user);
            return info;
        }
    }
}