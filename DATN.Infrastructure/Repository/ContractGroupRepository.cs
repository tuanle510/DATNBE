using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infrastructure.Repository
{
    public class ContractGroupRepository : BaseRepository<ContractGroupEntity>, IContractGroupRepository
    {
        public ContractGroupRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
