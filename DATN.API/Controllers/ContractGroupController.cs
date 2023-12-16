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
    public class ContractGroupController : BaseBusinessController<ContractGroupEntity>
    {
        IContractGroupRepository _contractGroupRepository;
        IContractGroupService _contractGroupService;

        IContractRepository _contractRepository;
        public ContractGroupController(IContractGroupRepository contractGroupRepository, IContractGroupService contractGroupService, IContractRepository contractRepository) : base(contractGroupRepository, contractGroupService)
        {
            _contractGroupRepository = contractGroupRepository;
            _contractGroupService = contractGroupService;

            _contractRepository = contractRepository;
        }

        /// <summary>
        /// Xử lí lấy dữ liệu về theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        public override IActionResult Get(Guid entityId)
        {
            try
            {
                var master = _contractGroupRepository.GetById(entityId);
                var details = _contractRepository.GetByMasterId(entityId);
                var res = new ContractGroupParam()
                {
                    master = master,
                    details = details
                };
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
