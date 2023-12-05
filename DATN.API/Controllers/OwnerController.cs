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
    public class OwnerController : BaseBusinessController<OwnerEntity>
    {
        IOwnerRepository _ownerRepository;
        IOwnerService _ownerService;
        public OwnerController(IOwnerRepository ownerRepository, IOwnerService ownerService) : base (ownerRepository, ownerService)
        {
            _ownerRepository = ownerRepository;
            _ownerService = ownerService;
        }
    }
}
