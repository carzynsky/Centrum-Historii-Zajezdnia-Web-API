using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public interface IMeasurementRepository
    {
        Task<List<Measurement>> GetAllMeasurement(int id);
        Task<List<Measurement>> GetAllOfMeasurement();
        Task<List<Measurement>> GetLastWeekMeasurement(int id);
        Task<List<Measurement>> GetLastFiveYearsMeasurement(int id);
        Task<int> GetNumberOfAllMeasurement(int id);
        Task<int> GetNumberOfMeasurementThisMonth(int id);
        Task<int> GetNumberOfMeasurementToday(int id);
    }
}
