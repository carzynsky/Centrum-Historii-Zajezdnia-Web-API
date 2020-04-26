using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class LoginHistory
    {
        [Key]
        public int Id { get; set; }
        public string Success { get; set; }
        public string UserLogin{ get; set; }
        public string UserPassword { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}
