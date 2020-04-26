using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsersWithInfo();
        Task<Users> FindUserByLoginAndPassword(Users user);
        Task<Users> FindUserByLogin(string login);
    }
}
