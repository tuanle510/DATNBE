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
    public class CanHoController : BaseBusinessController<CanHoEntity>
    {
        ICanHoRepository _canHoRepository;
        ICanHoService _canHoService;
        public CanHoController(ICanHoRepository CanHoRepository, ICanHoService CanHoService) : base(CanHoRepository, CanHoService)
        {
            _canHoRepository = CanHoRepository;
            _canHoService = CanHoService;
        }
    }
}
