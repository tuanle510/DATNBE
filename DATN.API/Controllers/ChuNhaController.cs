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
    public class ChuNhaController : BaseBusinessController<ChuNhaEntity>
    {
        IChuNhaRepository _chuNhaRepository;
        IChuNhaService _chuNhaService;
        public ChuNhaController(IChuNhaRepository ChuNhaRepository, IChuNhaService ChuNhaService) : base (ChuNhaRepository, ChuNhaService)
        {
            _chuNhaRepository = ChuNhaRepository;
            _chuNhaService = ChuNhaService;
        }
    }
}
