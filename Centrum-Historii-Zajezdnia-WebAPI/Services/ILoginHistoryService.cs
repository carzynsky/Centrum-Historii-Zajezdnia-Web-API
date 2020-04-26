using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public interface ILoginHistoryService
    {
        Task<List<LoginHistory>> GetAllWithUsers();
        Task<List<LoginHistory>> GetByUserId(int id);
        Task DeleteHistory();
    }
}
