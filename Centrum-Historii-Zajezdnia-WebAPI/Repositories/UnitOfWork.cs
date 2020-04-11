using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MonitoringContext _context;
        private LoginRepository loginRepository;
        private MeasurementRepository measurementRepository;

        public UnitOfWork(MonitoringContext context)
        {
            _context = context;
        }

        public LoginRepository LoginRepository
        {
            get
            {
                return loginRepository = loginRepository ?? new LoginRepository(_context);
            }
        }

        public MeasurementRepository MeasurementRepository
        {
            get
            {
                return measurementRepository = measurementRepository ?? new MeasurementRepository(_context);
            }
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
