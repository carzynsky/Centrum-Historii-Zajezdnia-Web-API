using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public interface IMeasurementService
    {
        Task<List<Measurement>> GetAll();
        Task<List<Measurement>> GetAll(int id);
        Task<List<float>> GetAverageTemperatureByEachMonth(int id);
        Task<List<float>> GetAverageHumidityByEachMonth(int id);
        Task<List<float>> GetAverageTemperatureLastWeek(int id);
        Task<List<float>> GetAverageHumidityLastWeek(int id);
        Task<List<float>> GetAverageTemperatureLastYears(int id);
        Task<List<float>> GetAverageHumidityLastYears(int id);
        Task<int> GetNumberOfAllMeasurement(int id);
        Task<int> GetNumberOfMeasurementThisMonth(int id);
        Task<int> GetNumberOfMeasurementToday(int id);
        Task<List<SensorInfo>> GetLastMeasurement();
        Task<List<float>> GetInformationForReport(int id);
    }
}
