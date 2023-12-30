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

        /// <summary>
        ///  Thêm mới
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
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
        ///  Thêm mới
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPut("custom")]
        public IActionResult Put(ContractParam param)
        {
            try
            {
                var res = _contractService.UpdateService(param.master);
                if (param.details != null && param.details.Count > 0)
                {
                    for (int i = 0; i < param.details.Count; i++)
                    {
                        switch (param.details[i].state)
                        {
                            case "insert":
                                _paymentTransactionService.InsertService(param.details[i]);
                                break;
                            case "update":
                                _paymentTransactionService.UpdateService(param.details[i]);
                                break;
                            case "delete":
                                _paymentTransactionService.DeleteService(new List<Guid>() { param.details[i].payment_transaction_id });
                                break;
                        }
                    }
                }
                return StatusCode(200, res);
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
                // Gán thêm trạng thái là không làm gì 
                if (details.Count > 0)
                {
                    foreach (var item in details)
                    {
                        item.state = "None";
                    }
                }
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
