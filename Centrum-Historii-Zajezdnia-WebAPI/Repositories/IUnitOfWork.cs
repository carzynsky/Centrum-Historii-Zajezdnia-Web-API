﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Centrum_Historii_Zajezdnia_WebAPI.Repositories
{
    public interface IUnitOfWork
    {
        LoginRepository LoginRepository { get; }
        MeasurementRepository MeasurementRepository { get; }
        void save();
    }
}