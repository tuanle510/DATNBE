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
    public class ProvinceService : BaseService<ProvinceEntity>, IProvinceService
    {
        IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository) : base(provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
    }
}
