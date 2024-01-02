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
    public class ContractServiceService : BaseService<ContractServiceEntity>, IContractServiceService
    {
        IContractServiceRepository _contractServiceRepository;
        public ContractServiceService(IContractServiceRepository contractServiceRepository) : base(contractServiceRepository)
        {
            _contractServiceRepository = contractServiceRepository;
        }
    }
}
