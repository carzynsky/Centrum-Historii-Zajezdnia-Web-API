using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public interface IMonitoringGeneric<T> where T : class
    {
        Task<List<T>> GetAll();
        IQueryable<T> Get();
        Task<T> GetById(int id);
        void DeleteById(int id);
        void Update(T entity);
        Task Create(T entity);
        Task SaveAsync();
    }
}
