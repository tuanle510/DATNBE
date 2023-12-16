using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using DATN.Core.Params;
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

        IPaymentTransactionService _paymentTransactionService;
        IPaymentTransactionRepository _paymentTransactionRepository;
        public ContractController(IContractRepository contractRepository, IContractService contractService, IPaymentTransactionService paymentTransactionService, IPaymentTransactionRepository paymentTransactionRepository) : base (contractRepository, contractService)
        {
            _contractRepository = contractRepository;
            _contractService = contractService;

            _paymentTransactionService = paymentTransactionService;
            _paymentTransactionRepository = paymentTransactionRepository;
        }

        [HttpPost("custom")]
        public IActionResult Post(ContractParam param)
        {
            try
            {
                var res = _contractService.InsertService(param.master);
                if (param.details != null && param.details.Count > 0)
                {
                    for (int i = 0; i < param.details.Count; i++)
                    {
                        _paymentTransactionService.InsertService(param.details[i]);
                    }
                }
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
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
                var master = _contractRepository.GetById(entityId);
                var details = _paymentTransactionRepository.GetByMasterId(entityId);
                var res = new ContractParam()
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
