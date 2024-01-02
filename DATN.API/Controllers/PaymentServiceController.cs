using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using Microsoft.AspNetCore.Mvc;
using MISA.Web03.API.Controllers;
using DATN.Core.Interfaces.Services;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentServiceController : BaseBusinessController<PaymentServiceEntity>
    {
        IPaymentServiceRepository _paymentServiceRepository;
        IPaymentServiceService _paymentServiceService;
        public PaymentServiceController(IPaymentServiceRepository paymentServiceRepository, IPaymentServiceService paymentServiceService) : base (paymentServiceRepository, paymentServiceService)
        {
            _paymentServiceRepository = paymentServiceRepository;
            _paymentServiceService = paymentServiceService;
        }
    }
}
