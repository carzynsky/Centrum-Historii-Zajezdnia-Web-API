using Centrum_Historii_Zajezdnia_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public class UserFunctionsRepository : MonitoringGeneric<UserFunction>, IUserFunctionsRepository
    {
        MonitoringContext _context;

        public UserFunctionsRepository(MonitoringContext context) : base(context)
        {
            _context = context;
        }
    }
}
