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
        public BuildingService(IBuildingRepository buildingRepository) : base(buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }
    }
}
