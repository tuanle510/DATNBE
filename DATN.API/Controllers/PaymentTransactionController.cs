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
    public class PaymentTransactionController : BaseBusinessController<PaymentTransactionEntity>
    {
        IPaymentTransactionRepository _paymentTransactionRepository;
        IPaymentTransactionService _paymentTransactionService;
        public PaymentTransactionController(IPaymentTransactionRepository paymentTransactionRepository, IPaymentTransactionService paymentTransactionService) : base (paymentTransactionRepository, paymentTransactionService)
        {
            _paymentTransactionRepository = paymentTransactionRepository;
            _paymentTransactionService = paymentTransactionService;
        }
    }
}
