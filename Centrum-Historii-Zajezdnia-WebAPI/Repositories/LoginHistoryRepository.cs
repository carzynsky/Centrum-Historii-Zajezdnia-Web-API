using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class LoginHistoryRepository : MonitoringGeneric<LoginHistory>, ILoginHistoryRepository
    {
        MonitoringContext _context;
        public LoginHistoryRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LoginHistory>> GetAllWithUsers()
        {
            return await _context.LoginHistory.Include(u => u.Users).ToListAsync();
        }

        public async Task<List<LoginHistory>> GetByUserId(int id)
        {
            return await _context.LoginHistory.Where(x => x.UserId.Equals(id)).ToListAsync();
        }
    }
}
