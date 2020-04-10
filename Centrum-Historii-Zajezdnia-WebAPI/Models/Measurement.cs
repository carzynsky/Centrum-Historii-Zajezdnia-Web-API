using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime DateTime { get; set; }
        public int SensorId { get; set; }

        [ForeignKey("SensorId")]
        public virtual Sensors Sensors { get; set; }
    }
}
