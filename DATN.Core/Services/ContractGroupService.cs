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

        IContractRepository _contractRepository;
        IContractService _contractService;
        public ContractGroupService(IContractGroupRepository contractGroupRepository, IContractRepository contractRepository, IContractService contractService) : base(contractGroupRepository)
        {
            _contractGroupRepository = contractGroupRepository;

            _contractRepository = contractRepository;
            _contractService = contractService;

        }

        /// <summary>
        /// thò ra hàm xóa detail
        /// </summary>
        /// <param name="guid"></param>
        public override void deleteDetail(Guid guid)
        {
            var details = _contractRepository.GetByMasterId(guid);
            var listId = new List<Guid>();
            foreach (var item in details)
            {
                listId.Add(item.contract_id);
            }
            _contractService.DeleteService(listId);
        }
    }
}
