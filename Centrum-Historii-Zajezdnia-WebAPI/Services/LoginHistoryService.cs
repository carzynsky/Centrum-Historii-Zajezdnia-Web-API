using Centrum_Historii_Zajezdnia_WebAPI.Models;
using Centrum_Historii_Zajezdnia_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Services
{
    public class LoginHistoryService : ILoginHistoryService
    {
        private IUnitOfWork UnitOfWork;
        public LoginHistoryService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task DeleteHistory()
        {
            var history = await UnitOfWork.LoginHistoryRepository.GetAll();
            foreach(var row in history)
            {
                UnitOfWork.LoginHistoryRepository.DeleteById(row.Id);
            }
            await UnitOfWork.LoginHistoryRepository.SaveAsync();
        }

        /// <summary>
        /// Zwrócenie wszystkich logowań do systemu
        /// </summary>
        /// <returns></returns>
        public async Task<List<LoginHistory>> GetAllWithUsers()        {
            return await UnitOfWork.LoginHistoryRepository.GetAllWithUsers();
        }

        public async Task<List<LoginHistory>> GetByUserId(int id)
        {
            return await UnitOfWork.LoginHistoryRepository.GetByUserId(id);
        }
    }
}
