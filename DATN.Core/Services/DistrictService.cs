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
    public class DistrictService : BaseService<DistrictEntity>, IDistrictService
    {
        IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository)
        {
            _districtRepository = districtRepository;
        }
    }
}
