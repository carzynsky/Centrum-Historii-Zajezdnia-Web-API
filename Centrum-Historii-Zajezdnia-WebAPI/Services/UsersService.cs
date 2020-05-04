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

        /// <summary>
        /// Zwraca wszystkie funkcje/role użytkowników
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserFunction>> GetAllFunctions()
        {
            return await UnitOfWork.UserFunctionsRepository.GetAll();
        }

        /// <summary>
        /// Zwrócenie wszystkich użytkowników w bazie z rolami
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await UnitOfWork.UsersRepository.GetAllUsersWithInfo();
        }

        /// <summary>
        /// Dodanie użytkownika do bazy i zwrócenie informacji o poprawności operacji
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> IsCreateSuccessfull(Users user)
        {
            var alreadyCreated = false; // todo, assumed that newUser is not in db
            if(alreadyCreated)
            {
                return false;
            }
            else
            {
                Users newUser = new Users()
                {
                    Login = user.Login,
                    Password = user.Password,
                    UserFunctionId = user.UserFunctionId
                };

                await UnitOfWork.UsersRepository.Create(newUser);
                await UnitOfWork.UsersRepository.SaveAsync();
                return true;
            }
        }

        /// <summary>
        /// Usunięcie użytkownika o podanym id i zwrócenie informacji o rezultacie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> IsDeleteSuccessfull(int id)
        {
            var user = await UnitOfWork.UsersRepository.GetById(id);
            if(user == null)
            {
                return false;
            }
            else
            {
                UnitOfWork.UsersRepository.DeleteById(id);
                await UnitOfWork.UsersRepository.SaveAsync();
                return true;
            }
        }

        /// <summary>
        /// Aktualizacja danych użytkownika i zwrócenie informacji o rezultacie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> IsUpdateSuccessfull(int id, Users user)
        {
            var _user = await UnitOfWork.UsersRepository.GetById(id);
            if(user == null || id != _user.Id)
            {
                return false;
            }
            else
            {
                _user.Login = user.Login;
                _user.Password = user.Password;
                _user.UserFunctionId = user.UserFunctionId;
                UnitOfWork.UsersRepository.Update(_user);
                await UnitOfWork.UsersRepository.SaveAsync();
                return false;
            }
        }

        public async Task<Response> UserSignin(Users user)
        {
            var login = await UnitOfWork.UsersRepository.FindUserByLoginAndPassword(user);

            if (login != null)
            {
                DateTime date = DateTime.Now;
                LoginHistory newLogin = new LoginHistory()
                {
                    Success = "Ok",
                    UserLogin = login.Login,
                    UserPassword = login.Password,
                    UserId = login.Id,
                    DateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind)
                };
                await UnitOfWork.LoginHistoryRepository.Create(newLogin);
                await UnitOfWork.LoginHistoryRepository.SaveAsync();

                switch (login.UserFunction.Function)
                {
                    case "admin":
                        {
                            return new Response { Status = "Success", Message = "Logged Successfully", Function = "admin" };
                        }
                    case "technician":
                        {
                            return new Response { Status = "Success", Message = "Logged Successfully", Function = "technician" };
                        }
                    case "employee":
                    default:
                        {
                            return new Response { Status = "Success", Message = "Logged Successfully", Function = "employee" };
                        }
                }
            }
            else
            {
                var checkIfUserExists = await UnitOfWork.UsersRepository.FindUserByLogin(user.Login);
                if (checkIfUserExists != null)
                {
                    DateTime date = DateTime.Now;
                    LoginHistory newLogin = new LoginHistory()
                    {
                        Success = "Niepoprawne hasło",
                        UserLogin = user.Login,
                        UserPassword = user.Password,
                        UserId = checkIfUserExists.Id,
                        DateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind)

                };
                    await UnitOfWork.LoginHistoryRepository.Create(newLogin);
                    await UnitOfWork.LoginHistoryRepository.SaveAsync();

                    return new Response { Status = "Error", Message = "Invalid Password!", Function = "null" };
                }
                else
                {              
                    return new Response { Status = "Error", Message = "Invalid Login", Function = "null" };
                }

            }
        }
    }
}
