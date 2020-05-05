using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Models
{
    public class SensorInfo
    {
        public int Id { get; set; }
        public string SensorName { get; set; }
        public string Info { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime DateTime { get; set; }
        public int MinutesAgo { get; set; }
    }
}
