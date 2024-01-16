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
    public class WardController : BaseBusinessController<WardEntity>
    {
        IWardRepository _wardRepository;
        IWardService _wardService;
        public WardController(IWardRepository wardRepository, IWardService wardService) : base(wardRepository, wardService)
        {
            _wardRepository = wardRepository;
            _wardService = wardService;
        }
    }
}
