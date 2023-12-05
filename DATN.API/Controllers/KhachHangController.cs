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
    public class KhachHangController : BaseBusinessController<KhachHangEntity>
    {
        IKhachHangRepository _khachHangRepository;
        IKhachHangService _khachHangService;
        public KhachHangController(IKhachHangRepository KhachHangRepository, IKhachHangService KhachHangService) : base(KhachHangRepository, KhachHangService)
        {
            _khachHangRepository = KhachHangRepository;
            _khachHangService = KhachHangService;
        }
    }
}
    