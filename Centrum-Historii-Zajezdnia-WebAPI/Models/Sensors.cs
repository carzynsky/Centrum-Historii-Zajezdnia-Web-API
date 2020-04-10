using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class Sensors
    {
        [Key]
        public int Id { get; set; }
        public string SensorName { get; set; }
        public List<Measurement> Measurement { get; set; }
    }
}
