using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class MeasurementService : IMeasurementService
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public MeasurementService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Metoda zwraca wszystkie pomiary
        /// </summary>
        /// <returns></returns>
        public List<Measurement> GetAll()
        {
            return UnitOfWork.MeasurementRepository.GetAllMeasurement();
        }
    }
}
