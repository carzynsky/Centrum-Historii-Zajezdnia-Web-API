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

        public async Task<List<Measurement>> GetAllOfMeasurement()
        {
            return await _context.Measurement.Include(s => s.Sensors).ToListAsync();
        }

        public async Task<List<Measurement>> GetAllMeasurement(int id)
        {
            DateTime newDate = DateTime.Now;
            return await _context.Measurement.Where(x => x.SensorId.Equals(id) && x.DateTime.Year.Equals(newDate.Year)).Include(s => s.Sensors).ToListAsync();
        }

        public async Task<int> GetNumberOfAllMeasurement(int id)
        {
            return await _context.Measurement.Where(x => x.SensorId.Equals(id)).CountAsync();
        }

        public async Task<int> GetNumberOfMeasurementThisMonth(int id)
        {
            return await _context.Measurement.Where(x => x.SensorId.Equals(id) && x.DateTime.Month.Equals(DateTime.Now.Month) && x.DateTime.Year.Equals(DateTime.Now.Year)).CountAsync();
        }

        public async Task<int> GetNumberOfMeasurementToday(int id)
        {
            return await _context.Measurement.Where(x => x.SensorId.Equals(id) &&  x.DateTime.Month.Equals(DateTime.Now.Month) && x.DateTime.Year.Equals(DateTime.Now.Year)
                && x.DateTime.Day.Equals(DateTime.Now.Day)).CountAsync();

        }

        public async Task<List<Measurement>> GetLastWeekMeasurement(int id)
        {
            return await _context.Measurement.Where(x => x.SensorId.Equals(id) && x.DateTime >= DateTime.Now.AddDays(-7)).Include(s => s.Sensors).ToListAsync();
        }

        public async Task<List<Measurement>> GetLastFiveYearsMeasurement(int id)
        {
            return await _context.Measurement.Where(x => x.SensorId.Equals(id) && x.DateTime >= DateTime.Now.AddYears(-4)).Include(s => s.Sensors).ToListAsync();
        }
    }
}
