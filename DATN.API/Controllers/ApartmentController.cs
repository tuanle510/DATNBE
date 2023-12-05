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
    public class ApartmentController : BaseBusinessController<ApartmentEntity>
    {
        IApartmentRepository _apartmentRepository;
        IApartmentService _apartmentService;
        public ApartmentController(IApartmentRepository apartmentRepository, IApartmentService apartmentService) : base(apartmentRepository, apartmentService)
        {
            _apartmentRepository = apartmentRepository;
            _apartmentService = apartmentService;
        }
    }
}
