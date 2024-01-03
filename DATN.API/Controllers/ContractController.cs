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

        IPaymentServiceService _paymentServiceService;
        IPaymentServiceRepository _paymentServiceRepository;

        IContractServiceService _contractServiceService;
        IContractServiceRepository _contractServiceRepository;
        public ContractController(
            IContractRepository contractRepository, IContractService contractService,
            IContractServiceRepository contractServiceRepository, IContractServiceService contractServiceService,
            IPaymentServiceRepository paymentServiceRepository, IPaymentServiceService paymentServiceService, 
            IPaymentTransactionService paymentTransactionService, IPaymentTransactionRepository paymentTransactionRepository
            ) 
            : base (contractRepository, contractService)
        {
            _contractRepository = contractRepository;
            _contractService = contractService;

            _contractServiceRepository = contractServiceRepository;
            _contractServiceService = contractServiceService;

            _paymentServiceService = paymentServiceService;
            _paymentServiceRepository = paymentServiceRepository;

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
                
                if (param.detailsService != null && param.detailsService.Count > 0)
                {
                    for (int i = 0; i < param.detailsService.Count; i++)
                    {
                        _paymentServiceService.InsertService(param.detailsService[i]);
                    }
                }     
                
                if (param.service != null && param.service.Count > 0)
                {
                    for (int i = 0; i < param.service.Count; i++)
                    {
                        _contractServiceService.InsertService(param.service[i]);
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
                // Thanh toán hợp đông
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

                // Thanh toán dịch vụ
                if (param.detailsService != null && param.detailsService.Count > 0)
                {
                    for (int i = 0; i < param.detailsService.Count; i++)
                    {
                        switch (param.detailsService[i].state)
                        {
                            case "insert":
                                _paymentServiceService.InsertService(param.detailsService[i]);
                                break;
                            case "update":
                                _paymentServiceService.UpdateService(param.detailsService[i]);
                                break;
                            case "delete":
                                _paymentServiceService.DeleteService(new List<Guid>() { param.detailsService[i].payment_service_id });
                                break;
                        }
                    }
                }

                // Dịch vụ
                if (param.service != null && param.service.Count > 0)
                {
                    for (int i = 0; i < param.service.Count; i++)
                    {
                        switch (param.service[i].state)
                        {
                            case "insert":
                                _contractServiceService.InsertService(param.service[i]);
                                break;
                            case "update":
                                _contractServiceService.UpdateService(param.service[i]);
                                break;
                            case "delete":
                                _contractServiceService.DeleteService(new List<Guid>() { param.service[i].contract_service_id });
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
                var serviceDetail = _paymentServiceRepository.GetByMasterId(entityId);
                var serviceList = _contractServiceRepository.GetByMasterId(entityId);
                // Gán thêm trạng thái là không làm gì 
                if (details.Count > 0)
                {
                    foreach (var item in details)
                    {
                        item.state = "none";
                    }
                }                
                if (serviceDetail.Count > 0)
                {
                    foreach (var item in serviceDetail)
                    {
                        item.state = "none";
                    }
                }                
                if (serviceList.Count > 0)
                {
                    foreach (var item in serviceList)
                    {
                        item.state = "none";
                    }
                }
                var res = new ContractParam()
                {
                    master = master,
                    details = details,
                    detailsService = serviceDetail,
                    service = serviceList
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
