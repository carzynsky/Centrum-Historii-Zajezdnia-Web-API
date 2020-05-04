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
        public IUnitOfWork UnitOfWork;
        public SensorsService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Metoda zwraca wszystkie czujniki
        /// </summary>
        /// <returns></returns>
        public async Task<List<Sensors>> GetAllSensors()
        {
            return await UnitOfWork.SensorsRepository.GetAll();
        }

        /// <summary>
        /// Metoda usuwa czujnik o danym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSensor(int id)
        {
            var sensorToDelete = await UnitOfWork.SensorsRepository.GetById(id);
            if(sensorToDelete == null)
            {
                return false;
            }
            else
            {
                UnitOfWork.SensorsRepository.DeleteById(id);
                await UnitOfWork.SensorsRepository.SaveAsync();
                return true;
            }
        }

        /// <summary>
        /// Edycja danych określonego czujnika
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sensor"></param>
        /// <returns></returns>
        public async Task<bool> EditSensor(int id, Sensors sensor)
        {
            var sensorToEdit = await UnitOfWork.SensorsRepository.GetById(id);
            if(sensorToEdit == null || id != sensor.Id)
            {
                return false;
            }
            else
            {
                sensorToEdit.SensorName = sensor.SensorName;
                sensorToEdit.IpAddress = sensor.IpAddress;
                sensorToEdit.ExternalIp = sensor.ExternalIp;
                sensorToEdit.Top = sensor.Top;
                sensorToEdit.Left = sensor.Left;
                UnitOfWork.SensorsRepository.Update(sensorToEdit);
                await UnitOfWork.SensorsRepository.SaveAsync();
                return true;
            }

        }

        /// <summary>
        /// Sprawdzenie czy czujnik o danej nazwie już jest w bazie, dodanie czujnika do bazy
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        public async Task<bool> CreateSensor(Sensors sensor)
        {
            var _sensor = await UnitOfWork.SensorsRepository.GetSensorByName(sensor.SensorName);
            if (_sensor == null)
            {
                Sensors newSensor = new Sensors()
                { 
                    SensorName = sensor.SensorName,
                    IpAddress = sensor.IpAddress,
                    ExternalIp = sensor.ExternalIp,
                    Top = sensor.Top,
                    Left = sensor.Left
                };
                await UnitOfWork.SensorsRepository.Create(newSensor);
                await UnitOfWork.SensorsRepository.SaveAsync();
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
