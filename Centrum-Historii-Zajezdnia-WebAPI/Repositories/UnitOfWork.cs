using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MonitoringContext _context;
        private MeasurementRepository measurementRepository;
        private SensorsRepository sensorsRepository;
        private UsersRepository usersRepository;

        public UnitOfWork(MonitoringContext context)
        {
            _context = context;
        }

        public MeasurementRepository MeasurementRepository
        {
            get
            {
                return measurementRepository = measurementRepository ?? new MeasurementRepository(_context);
            }
        }

        public SensorsRepository SensorsRepository
        {
            get
            {
                return sensorsRepository = sensorsRepository ?? new SensorsRepository(_context);
            }
        }

        public UsersRepository UsersRepository
        { 
            get
            {
                return usersRepository = usersRepository ?? new UsersRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
