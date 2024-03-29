﻿using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Interfaces.Respositories
{
    public interface IContractGroupRepository : IBaseRepository<ContractGroupEntity>
    {
        object GetDashboard(int year);
    }
}
