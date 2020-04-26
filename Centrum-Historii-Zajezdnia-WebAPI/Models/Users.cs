using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Password must be 5 characters or more")]
        public string Password { get; set; }
        public int UserFunctionId{ get; set; }

        [ForeignKey("UserFunctionId")]
        public virtual UserFunction UserFunction { get; set; }
        public List<LoginHistory> LoginHistories { get; set; }
    }
}
