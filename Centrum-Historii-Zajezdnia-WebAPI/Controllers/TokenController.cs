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
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        ISensorsService _service;
        public TokenController(ISensorsService service)
        {
            _service = service;
        }

    }
}