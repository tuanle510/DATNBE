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
    public class PaymentServiceService : BaseService<PaymentServiceEntity>, IPaymentServiceService
    {
        IPaymentServiceRepository _paymentServiceRepository;
        public PaymentServiceService(IPaymentServiceRepository paymentServiceRepository) : base(paymentServiceRepository)
        {
            _paymentServiceRepository = paymentServiceRepository;
        }
    }
}
