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
    public class OwnerService : BaseService<OwnerEntity>, IOwnerService
    {
        IOwnerRepository _ownerRepository;
        IApartmentRepository _apartmentRepository;
        IContractGroupRepository _contractGroupRepository;
        IContractRepository _contractRepository;
        public OwnerService(
            IOwnerRepository ownerRepository, 
            IApartmentRepository apartmentRepository, 
            IContractGroupRepository contractGroupRepository,
            IContractRepository contractRepository
            ) : base(ownerRepository)
        {
            _ownerRepository = ownerRepository;
            _apartmentRepository = apartmentRepository;
            _contractGroupRepository = contractGroupRepository;
            _contractRepository = contractRepository;
        }


        /// <summary>
        /// Gọi các danh sách liên quan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="master"></param>
        /// <returns></returns>
        public override object getDetailRef(Guid id, OwnerEntity master)
        {
            var tab1 = _apartmentRepository.GetByMasterId(id, nameof(OwnerEntity.owner_id));
            var tab2 = _contractGroupRepository.GetByMasterId(id, nameof(OwnerEntity.owner_id));
            var tab3 = _contractRepository.GetByMasterId(id, nameof(OwnerEntity.owner_id));
            var res = new
            {
                master = master,
                tab1 = tab1,
                tab2 = tab2,
                tab3 = tab3,
            };

            return res;
        }

        /// <summary>
        /// Check phát sinh khi xóa
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public override object? CheckArise(Guid guid)
        {
            var tab1 = _apartmentRepository.GetByMasterId(guid, nameof(OwnerEntity.owner_id));
            var tab2 = _contractGroupRepository.GetByMasterId(guid, nameof(OwnerEntity.owner_id));
            var tab3 = _contractRepository.GetByMasterId(guid, nameof(OwnerEntity.owner_id));
            var res = new
            {
                apartment = tab1.Count(),
                contractGroup = tab2.Count(),
                contract = tab3.Count(),
            };

            return (tab1?.Count() == 0 && tab2?.Count() == 0 && tab3?.Count() == 0) ? null : res;
        }
    }
}
