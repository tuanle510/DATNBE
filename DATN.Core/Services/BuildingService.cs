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
    public class BuildingService : BaseService<BuildingEntity>, IBuildingService
    {
        IBuildingRepository _buildingRepository;
        IApartmentRepository _apartmentRepository;
        public BuildingService(IBuildingRepository buildingRepository, IApartmentRepository apartmentRepository) : base(buildingRepository)
        {
            _buildingRepository = buildingRepository;
            _apartmentRepository = apartmentRepository;
        }

        /// <summary>
        /// Gọi các danh sách liên quan
        /// </summary>
        /// <param name="id"></param>
        /// <param name="master"></param>
        /// <returns></returns>
        public override object getDetailRef(Guid id, BuildingEntity master)
        {
            var tab1 = _apartmentRepository.GetByMasterId(id, nameof(BuildingEntity.building_id));
            var res = new
            {
                master = master,
                tab1 = tab1
            };

            return res;
        }
    }
}
