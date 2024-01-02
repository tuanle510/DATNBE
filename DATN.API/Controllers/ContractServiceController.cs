using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MISA.Web03.API.Controllers;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractServiceController : BaseBusinessController<ContractServiceEntity>
    {
        IContractServiceRepository _contractServiceRepository;
        IContractServiceService _contractServiceService;
        public ContractServiceController(IContractServiceRepository contractServiceRepository, IContractServiceService contractServiceService) : base (contractServiceRepository, contractServiceService)
        {
            _contractServiceRepository = contractServiceRepository;
            _contractServiceService = contractServiceService;
        }
    }
}
