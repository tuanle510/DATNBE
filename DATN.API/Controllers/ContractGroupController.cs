using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web03.API.Controllers;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractGroupController : BaseBusinessController<ContractGroupEntity>
    {
        IContractGroupRepository _contractGroupRepository;
        IContractGroupService _contractGroupService;
        public ContractGroupController(IContractGroupRepository contractGroupRepository, IContractGroupService contractGroupService) : base(contractGroupRepository, contractGroupService)
        {
            _contractGroupRepository = contractGroupRepository;
            _contractGroupService = contractGroupService;
        }
    }
}
