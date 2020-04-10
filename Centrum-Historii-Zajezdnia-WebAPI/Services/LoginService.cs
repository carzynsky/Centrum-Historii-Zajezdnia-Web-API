using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class LoginService:ILoginService
    {
        MonitoringContext _context;
        public LoginService(MonitoringContext context)
        {
            _context = context;
        }

        public DbSet<Users> Get()
        {
            var _users = _context.Users;
            return _users;
        }

        public Response SigningIn(Users user)
        {
            var _user = _context.Users.Where(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password)).FirstOrDefault();

            if (_user == null)
                return new Response { Status = "Error", Message = "Invalid User" };
            else
                return new Response { Status = "Success", Message = "Login Succesfully" };
        }
    }
}
