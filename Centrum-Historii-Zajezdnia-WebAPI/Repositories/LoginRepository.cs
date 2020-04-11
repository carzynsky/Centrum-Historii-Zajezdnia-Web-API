using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class LoginRepository : MonitoringGeneric<LoginRepository>, ILoginRepository
    {
        private readonly MonitoringContext _context;

        public LoginRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        public List<Users> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public Response Response(Users user)
        {
            var _user = _context.Users.Where(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password)).FirstOrDefault();

            if (_user == null)
                return new Response { Status = "Error", Message = "Invalid User" };
            else
                return new Response { Status = "Success", Message = "Login Succesfully" };
        }
    }
}
