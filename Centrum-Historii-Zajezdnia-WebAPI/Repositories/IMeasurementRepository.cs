using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public interface IMeasurementRepository
    {
        List<Measurement> GetAllMeasurement(int id);
        int GetNumberOfAllMeasurement();
    }
}
