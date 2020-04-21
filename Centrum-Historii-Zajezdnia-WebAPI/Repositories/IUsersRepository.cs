using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public interface IUsersRepository
    {
        List<Users> GetAllUsersWithInfo();
        Response Response(Users user);
        bool EditUser(int id, Users user);
        bool DeleteUser(int id);
        void CreateUser(Users user);
    }
}
