using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Repositories;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class SensorsService : ISensorsService
    {
        public IUnitOfWork _unitOfWork;
        public SensorsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Metoda zwraca wszystkie czujniki
        /// </summary>
        /// <returns></returns>
        public List<Sensors> GetAllSensors()
        {
            return _unitOfWork.SensorsRepository.GetAll();
        }
    }
}
