using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public interface IUsersService
    {
        List<Users> GetAllUsers();
        Response UserSignin(Users user);
        bool IsUpdateSuccessfull(int id, Users user);
        bool IsDeleteSuccessfull(int id);
        void CreateUser(Users user);
    }
}
