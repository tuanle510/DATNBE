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
    public class ContractService : BaseService<ContractEntity>, IContractService
    {
        IContractRepository _contractRepository;

        public ContractService(IContractRepository contractRepository) : base(contractRepository)
        {
            _contractRepository = contractRepository;
        }
    }
}
