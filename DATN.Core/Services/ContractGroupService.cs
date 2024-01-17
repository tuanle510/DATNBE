using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Services
{
    public class ContractGroupService : BaseService<ContractGroupEntity>, IContractGroupService
    {
        IContractGroupRepository _contractGroupRepository;
        public ContractGroupService(IContractGroupRepository contractGroupRepository, IContractRepository contractRepository, IContractService contractService) : base(contractGroupRepository)
        {
            _contractGroupRepository = contractGroupRepository;
        }
    }
}
