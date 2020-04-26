using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Response> UserSignin(Users user);
        Task<bool> IsUpdateSuccessfull(int id, Users user);
        Task<bool> IsDeleteSuccessfull(int id);
        Task<bool> IsCreateSuccessfull(Users user);
        Task<List<UserFunction>> GetAllFunctions();
    }
}
