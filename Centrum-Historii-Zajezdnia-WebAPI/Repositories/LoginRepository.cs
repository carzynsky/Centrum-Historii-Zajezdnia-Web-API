using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class LoginRepository : MonitoringGeneric<Users>, ILoginRepository
    {
        private readonly MonitoringContext _context;

        public LoginRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        public List<Users> GetAllUsersWithInfo()
        {
            return _context.Users.Include(x => x.UserFunction).ToList();
        }

        public Response Response(Users user)
        {
            var _user = _context.Users.Where(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password)).FirstOrDefault();
            if(_user == null)
            {
                return new Response { Status = "Error", Message = "Invalid User", Function = "null" };
            }
            else
            {
                switch (_user.UserFunctionId)
                {
                    case 1:
                        {
                            return new Response { Status = "Success", Message = "Logged Successfully", Function = "admin" };
                        }
                    case 2:
                        {
                            return new Response { Status = "Success", Message = "Logged Successfully", Function = "technician" };
                        }
                    case 3:
                    default:
                        {
                            return new Response { Status = "Success", Message = "Logged Successfully", Function = "employee" };
                        }
                }

            }
        }
    }
}
