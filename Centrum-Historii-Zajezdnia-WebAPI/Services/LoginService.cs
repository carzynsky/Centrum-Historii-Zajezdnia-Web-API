using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class LoginService : ILoginService
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public LoginService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public List<Users> Get()
        {
            var users =  UnitOfWork.LoginRepository.GetAll();
            return users;
        }


        public Response UserSignin(Users user)
        {
            return UnitOfWork.LoginRepository.Response(user);
        }

        public List<Users> GetAllUsers()
        {
            return UnitOfWork.LoginRepository.GetAllUsersWithInfo();
        }
    }
}
