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
    public class ProvinceController : BaseBusinessController<ProvinceEntity>
    {
        IProvinceRepository _provinceRepository;
        IProvinceService _provinceService;
        public ProvinceController(IProvinceRepository provinceRepository, IProvinceService provinceService) : base(provinceRepository, provinceService)
        {
            _provinceRepository = provinceRepository;
            _provinceService = provinceService;
        }
    }
}
