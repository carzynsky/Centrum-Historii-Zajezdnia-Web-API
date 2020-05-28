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
        public string IpAddress{ get; set; }
        public string ExternalIp { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public string AddedBy { get; set; }
        public List<Measurement> Measurement { get; set; }
    }
}
