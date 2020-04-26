using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public interface ISensorsService
    {
        Task<List<Sensors>> GetAllSensors();
        Task<bool> DeleteSensor(int id);
        Task<bool> EditSensor(int id, Sensors sensor);
        Task<bool> CreateSensor(Sensors sensor);
    }
}
