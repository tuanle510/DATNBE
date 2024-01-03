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
        /// <summary>
        /// Thanh toán hợp đồng
        /// </summary>
        public List<PaymentTransactionEntity>? details { get; set; }
        /// <summary>
        /// Thanh toán dịch vụ
        /// </summary>
        public List<PaymentServiceEntity>? detailsService { get; set; }
        /// <summary>
        /// Dịch vụ
        /// </summary>
        public List<ContractServiceEntity>? service { get; set; }
    }
}
