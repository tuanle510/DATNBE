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
    public class ContractService : BaseService<ContractEntity>, IContractService
    {
        IContractRepository _contractRepository;
        IContractServiceRepository _contractServiceRepository;
        IPaymentServiceRepository _paymentServiceRepository;
        IPaymentTransactionRepository _paymentTransactionRepository;

        public ContractService(
            IContractRepository contractRepository,
            IContractServiceRepository contractServiceRepository,
            IPaymentServiceRepository paymentServiceRepository,
            IPaymentTransactionRepository paymentTransactionRepository) : base(contractRepository)
        {
            _contractRepository = contractRepository;
            _contractServiceRepository = contractServiceRepository;
            _paymentServiceRepository = paymentServiceRepository;
            _paymentTransactionRepository = paymentTransactionRepository;
         }

        /// <summary>
        /// thò ra hàm xóa detail
        /// </summary>
        /// <param name="guid"></param>
        //public override void deleteDetail(Guid guid)
        //{
        //    _contractServiceRepository.DeleteByMasterId(guid);
        //    _paymentServiceRepository.DeleteByMasterId(guid);
        //    _paymentTransactionRepository.DeleteByMasterId(guid);
        //}
    }
}
