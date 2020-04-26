using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class UsersRepository : MonitoringGeneric<Users>, IUserRepository
    {
        private readonly MonitoringContext _context;

        public UsersRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Dostęp do wszystkich użytkowników wraz z funkcją
        /// </summary>
        /// <returns></returns>
        public async Task<List<Users>> GetAllUsersWithInfo()
        {
            return await _context.Users.Include(x => x.UserFunction).ToListAsync();
        }

        /// <summary>
        /// Znalezienie użytkownika o danym loginie i haśle
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Users> FindUserByLoginAndPassword(Users user)
        {
            return await _context.Users.Where(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password)).Include(f => f.UserFunction).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Znalezienie użytkownika o danym loginie
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<Users> FindUserByLogin(string login)
        {
            return await _context.Users.Where(x => x.Login.Equals(login)).SingleOrDefaultAsync();
        }
    }
}
