using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class SensorsRepository : MonitoringGeneric<Sensors>, ISensorsRepository
    {
        MonitoringContext _context;
        public SensorsRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Dostęp do sensora o danej nazwie
        /// </summary>
        /// <returns></returns>
        public async Task<Sensors> GetSensorByName(string name)
        {
            return await _context.Sensors.Where(x => x.SensorName.Equals(name)).SingleOrDefaultAsync();
        }
    }
}
