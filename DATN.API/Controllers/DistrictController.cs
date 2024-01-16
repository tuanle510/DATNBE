using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web03.API.Controllers;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseBusinessController<DistrictEntity>
    {
        IDistrictRepository _districtRepository;
        IDistrictService _districtService;
        public DistrictController(IDistrictRepository districtRepository, IDistrictService districtService) : base(districtRepository, districtService)
        {
            _districtRepository = districtRepository;
            _districtService = districtService;
        }
    }
}
