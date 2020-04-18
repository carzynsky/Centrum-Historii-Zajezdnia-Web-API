using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class UserFunction
    {
        [Key]
        public int Id{ get; set; }
        public string Function{ get; set; }
        public List<Users> Users { get; set; }
    }
}
