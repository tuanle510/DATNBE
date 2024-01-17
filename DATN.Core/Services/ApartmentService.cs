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
    public class ApartmentService : BaseService<ApartmentEntity>, IApartmentService
    {
        IApartmentRepository _apartmentRepository;

        IContractGroupRepository _contractGroupRepository;
        IContractRepository _contractRepository;
        public ApartmentService(
            IApartmentRepository apartmentRepository,
            IContractGroupRepository contractGroupRepository,
            IContractRepository contractRepository
            ) : base(apartmentRepository)
        {
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
        public override object getDetailRef(Guid id, ApartmentEntity master)
        {
            var tab1 = _contractGroupRepository.GetByMasterId(id, nameof(ApartmentEntity.apartment_id));
            var tab2 = _contractRepository.GetByMasterId(id, nameof(ApartmentEntity.apartment_id));
            var res = new
            {
                master = master,
                tab1 = tab1,
                tab2 = tab2,
            };

            return res;
        }
    }
}
