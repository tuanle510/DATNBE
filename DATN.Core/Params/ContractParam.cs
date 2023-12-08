using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Params
{
    public class ContractParam
    {
        public  ContractEntity master { get; set; }
        public List<PaymentTransactionEntity>? details { get; set; }
    }
}
