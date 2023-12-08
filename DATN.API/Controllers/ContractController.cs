using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using DATN.Core.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web03.API.Controllers;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : BaseBusinessController<ContractEntity>
    {
        IContractRepository _contractRepository;
        IContractService _contractService;
        public ContractController(IContractRepository contractRepository, IContractService contractService) : base (contractRepository, contractService)
        {
            _contractRepository = contractRepository;
            _contractService = contractService;
        }

        [HttpPost("custom")]
        public IActionResult Post([FromBody] ContractParam param)
        {
            try
            {
                var res = _contractService.InsertService(param.master);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
