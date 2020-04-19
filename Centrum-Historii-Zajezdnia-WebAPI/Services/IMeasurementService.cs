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
        List<Measurement> GetAll();
        List<float> GetAverageTemperatureByEachMonth(int id);
        List<float> GetAverageHumidityByEachMonth(int id);
        List<float> GetAverageTemperatureLastWeek(int id);
        List<float> GetAverageHumidityLastWeek(int id);
        int GetNumberOfAllMeasurement();
    }
}
