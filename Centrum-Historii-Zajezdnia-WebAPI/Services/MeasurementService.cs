using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        public List<float> GetAverageTemperatureByEachMonth()
        {
            var all = UnitOfWork.MeasurementRepository.GetAllMeasurement();
            float[,] table = new float[,] {
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0},
                {0,0}
            };

            foreach(var item in all)
            {
                var tmp = item.DateTime.Month-1;
                table[tmp, 0] += item.Temperature;
                table[tmp, 1] += 1;
            }
            List<float> myList = new List<float>();
            for(int i=0; i<table.GetLength(0); i++)
            {
                if(table[i,1] != 0)
                {
                    myList.Add((table[i, 0] / table[i, 1]));
                }
                else
                {
                    myList.Add(table[i, 0]);
                }
            }
            return myList;
            
        }
    }
}
