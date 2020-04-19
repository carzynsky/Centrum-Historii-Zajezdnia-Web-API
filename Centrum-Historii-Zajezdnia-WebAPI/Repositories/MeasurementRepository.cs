using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class MeasurementRepository : MonitoringGeneric<Measurement>, IMeasurementRepository
    {
        private readonly MonitoringContext _context;

        public MeasurementRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        public List<Measurement> GetAllMeasurement(int id)
        {
            return _context.Measurement.Where(x => x.SensorId.Equals(id) && x.DateTime.Year.Equals(2020)).Include(s => s.Sensors).ToList();
        }

        public int GetNumberOfAllMeasurement(int id)
        {
            return _context.Measurement.Where(x => x.SensorId.Equals(id)).Count();
        }

        public int GetNumberOfMeasurementThisMonth(int id)
        {
            return _context.Measurement.Where(x => x.SensorId.Equals(id) && x.DateTime.Month.Equals(DateTime.Now.Month) && x.DateTime.Year.Equals(DateTime.Now.Year)).Count();
        }

        public int GetNumberOfMeasurementToday(int id)
        {
            return _context.Measurement.Where(x => x.SensorId.Equals(id) &&  x.DateTime.Month.Equals(DateTime.Now.Month) && x.DateTime.Year.Equals(DateTime.Now.Year)
                && x.DateTime.Day.Equals(DateTime.Now.Day)).Count();

        }
    }
}
