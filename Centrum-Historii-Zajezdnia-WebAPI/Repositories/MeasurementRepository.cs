using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class MeasurementRepository : MonitoringGeneric<MeasurementRepository>, IMeasurementRepository
    {
        private readonly MonitoringContext _context;

        public MeasurementRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        public List<Measurement> GetAllMeasurement()
        {
            return _context.Measurement.Include(s => s.Sensors).ToList();
        }
    }
}
