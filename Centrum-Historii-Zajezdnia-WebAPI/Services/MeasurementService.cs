using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class MeasurementService:IMeasurementService
    {
        MonitoringContext _context;
        public MeasurementService(MonitoringContext context)
        {
            _context = context;
        }

        public List<Measurement> GetAll()
        {
            var measurement = _context.Measurement.Include(s => s.Sensors).ToList();
            return measurement;
        }
    }
}
