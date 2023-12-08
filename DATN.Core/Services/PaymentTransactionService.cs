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
    public class PaymentTransactionService : BaseService<PaymentTransactionEntity>, IPaymentTransactionService
    {
        IPaymentTransactionRepository _paymentTransactionRepository;
        public PaymentTransactionService(IPaymentTransactionRepository paymentTransactionRepository) : base(paymentTransactionRepository)
        {
            _paymentTransactionRepository = paymentTransactionRepository;
        }
    }
}
