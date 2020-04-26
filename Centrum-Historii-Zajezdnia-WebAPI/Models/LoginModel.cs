using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int FunctionId { get; set; }
    }
}
