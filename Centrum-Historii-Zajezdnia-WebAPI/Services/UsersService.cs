using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork UnitOfWork;
        public UsersService(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }

        public List<Users> GetAllUsers()
        {
            var _users = UnitOfWork.UsersRepository.GetAllUsersWithInfo();
            return _users;
        }

        public void CreateUser(Users user)
        {
            UnitOfWork.UsersRepository.CreateUser(user);
        }

        public bool IsDeleteSuccessfull(int id)
        {
            var _delete = UnitOfWork.UsersRepository.DeleteUser(id);
            return _delete;
        }

        public bool IsUpdateSuccessfull(int id, Users user)
        {
            var _edit = UnitOfWork.UsersRepository.EditUser(id, user);
            return _edit;
        }
        public Response UserSignin(Users user)
        {
            return UnitOfWork.UsersRepository.Response(user);
        }
    }
}
