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
        public async Task<List<Measurement>> GetAll()
        {
            return await UnitOfWork.MeasurementRepository.GetAllOfMeasurement();
        }

        /// <summary>
        /// Metoda zwraca średnie pomiary temperatur dla każdego miesiąca dla podanego jako parametr czujnika
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<float>> GetAverageTemperatureByEachMonth(int id)
        {
            var all = await UnitOfWork.MeasurementRepository.GetAllMeasurement(id);
            float[,] table = new float[12,2];

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

        /// <summary>
        /// Funkcja zwracająca średnie temperatury z każdego miesiąca aktualnego roku dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<float>> GetAverageHumidityByEachMonth(int id)
        {
            var all = await UnitOfWork.MeasurementRepository.GetAllMeasurement(id);
            float[,] table = new float[12, 2];

            foreach (var item in all)
            {
                var tmp = item.DateTime.Month - 1;
                table[tmp, 0] += item.Humidity;
                table[tmp, 1] += 1;
            }
            List<float> myList = new List<float>();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i, 1] != 0)
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

        /// <summary>
        /// Funkcja zwracająca uśrednione pomiary temperatury z ostatniego tygodnia dla danego czujnika 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<float>> GetAverageTemperatureLastWeek(int id)
        {
            var measurement = await UnitOfWork.MeasurementRepository.GetLastWeekMeasurement(id);
            DateTime today = DateTime.Now;

            float[,] tab = new float[8, 2];
            int index;

            foreach (var item in measurement)
            {
                var tmp = item.DateTime;
                if(tmp.Day == today.AddDays(-7).Day)
                {
                    index = 0;
                }
                else if (tmp.Day == today.AddDays(-6).Day)
                {
                    index = 1;
                }
                else if (tmp.Day == today.AddDays(-5).Day)
                {
                    index = 2;
                }
                else if (tmp.Day == today.AddDays(-4).Day)
                {
                    index = 3;
                }
                else if (tmp.Day == today.AddDays(-3).Day)
                {
                    index = 4;
                }
                else if (tmp.Day == today.AddDays(-2).Day)
                {
                    index = 5;
                }
                else if (tmp.Day == today.AddDays(-1).Day)
                {
                    index = 6;
                }
                else
                {
                    index = 7;
                }

                tab[index, 0] += item.Temperature;
                tab[index, 1] += 1;
            }

            List<float> myList = new List<float>();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, 1] != 0)
                {
                    myList.Add((tab[i, 0] / tab[i, 1]));
                }
                else
                {
                    myList.Add(tab[i, 0]);
                }
            }
            return myList;
        }

        /// <summary>
        /// Funkcja zwaracająca uśrednione pomiary wilgotności powietrza z ostatniego tygodnia dla danego czujnika
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<float>> GetAverageHumidityLastWeek(int id)
        {
            var measurement = await UnitOfWork.MeasurementRepository.GetLastWeekMeasurement(id);
            DateTime today = DateTime.Now;

            float[,] tab = new float[8, 2];
            int index;

            foreach (var item in measurement)
            {
                var tmp = item.DateTime;
                if (tmp.Day == today.AddDays(-7).Day)
                {
                    index = 0;
                }
                else if (tmp.Day == today.AddDays(-6).Day)
                {
                    index = 1;
                }
                else if (tmp.Day == today.AddDays(-5).Day)
                {
                    index = 2;
                }
                else if (tmp.Day == today.AddDays(-4).Day)
                {
                    index = 3;
                }
                else if (tmp.Day == today.AddDays(-3).Day)
                {
                    index = 4;
                }
                else if (tmp.Day == today.AddDays(-2).Day)
                {
                    index = 5;
                }
                else if (tmp.Day == today.AddDays(-1).Day)
                {
                    index = 6;
                }
                else
                {
                    index = 7;
                }

                tab[index, 0] += item.Humidity;
                tab[index, 1] += 1;
            }

            List<float> myList = new List<float>();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, 1] != 0)
                {
                    myList.Add((tab[i, 0] / tab[i, 1]));
                }
                else
                {
                    myList.Add(tab[i, 0]);
                }
            }
            return myList;
        }

        public async Task<int> GetNumberOfAllMeasurement(int id)
        {
            return await UnitOfWork.MeasurementRepository.GetNumberOfAllMeasurement(id);
        }

        public async Task<int> GetNumberOfMeasurementThisMonth(int id)
        {
            return await UnitOfWork.MeasurementRepository.GetNumberOfMeasurementThisMonth(id);
        }

        public async Task<int> GetNumberOfMeasurementToday(int id)
        {
            return await UnitOfWork.MeasurementRepository.GetNumberOfMeasurementToday(id);
        }

        /// <summary>
        /// Metoda zwraca wszystkie pomiary dla określonego czujnika
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Measurement>> GetAll(int id)
        {
            var measurement = await UnitOfWork.MeasurementRepository.GetAllMeasurement(id);
            return measurement;
        }

        /// <summary>
        /// Metoda zwraca średnie pomiary temperatury dla ostatnich pięciu lat dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<float>> GetAverageTemperatureLastYears(int id)
        {
            var measurement = await UnitOfWork.MeasurementRepository.GetLastFiveYearsMeasurement(id);
            float [,] tab = new float[5, 2];
            var today = DateTime.Now;
            int index=0;

            foreach(var item in measurement)
            {
                var tmp = item.DateTime;

                if(tmp.Year == today.AddYears(-4).Year)
                {
                    index = 0;
                }
                if (tmp.Year == today.AddYears(-3).Year)
                {
                    index = 1;
                }
                if (tmp.Year == today.AddYears(-2).Year)
                {
                    index = 2;
                }
                if (tmp.Year == today.AddYears(-1).Year)
                {
                    index = 3;
                }
                if (tmp.Year == today.Year)
                {
                    index = 4;
                }
                tab[index, 0] += item.Temperature;
                tab[index, 1] += 1;
            }

            List<float> myList = new List<float>();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, 1] != 0)
                {
                    myList.Add((tab[i, 0] / tab[i, 1]));
                }
                else
                {
                    myList.Add(tab[i, 0]);
                }
            }
            return myList;
        }

        /// <summary>
        /// Funkcja zwraca średnie pomiary wilgotności powietrza dla ostatnich 5 lat dla czujnika o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<float>> GetAverageHumidityLastYears(int id)
        {
            var measurement = await UnitOfWork.MeasurementRepository.GetLastFiveYearsMeasurement(id);
            float[,] tab = new float[5, 2];
            var today = DateTime.Now;
            int index = 0;

            foreach (var item in measurement)
            {
                var tmp = item.DateTime;

                if (tmp.Year == today.AddYears(-4).Year)
                {
                    index = 0;
                }
                if (tmp.Year == today.AddYears(-3).Year)
                {
                    index = 1;
                }
                if (tmp.Year == today.AddYears(-2).Year)
                {
                    index = 2;
                }
                if (tmp.Year == today.AddYears(-1).Year)
                {
                    index = 3;
                }
                if (tmp.Year == today.Year)
                {
                    index = 4;
                }
                tab[index, 0] += item.Humidity;
                tab[index, 1] += 1;
            }

            List<float> myList = new List<float>();

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (tab[i, 1] != 0)
                {
                    myList.Add((tab[i, 0] / tab[i, 1]));
                }
                else
                {
                    myList.Add(tab[i, 0]);
                }
            }
            return myList;
        }
    }
}
