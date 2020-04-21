using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class UsersRepository : MonitoringGeneric<Users>, IUsersRepository
    {
        private readonly MonitoringContext _context;

        public UsersRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }

        public List<Users> GetAllUsersWithInfo()
        {
            return _context.Users.Include(x => x.UserFunction).ToList();
        }

        public bool EditUser(int id, Users user)
        {
            if (user.Id != id)
                return false;

            var _user = _context.Users.Where(x => x.Id.Equals(user.Id)).Single();
            if (_user == null)
            {
                return false;
            }
            else
            {
                _user.Login = user.Login;
                _user.Password = user.Password;
                _user.UserFunctionId = user.UserFunctionId;
                _context.Users.Update(_user);
                _context.SaveChanges();
                return true;
            }
        }

        public Response Response(Users user)
        {
            var _user = _context.Users.Where(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password)).FirstOrDefault();
            if (_user == null)
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

        public bool DeleteUser(int id)
        {
            var _user = _context.Users.Where(x => x.Id.Equals(id)).Single();
            if(_user == null)
            {
                return false;
            }
            else
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
                return true;
            }
        }

        public void CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
