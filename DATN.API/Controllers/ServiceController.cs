using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MISA.Web03.API.Controllers;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseBusinessController<ServiceEntity>
    {
        IServiceRepository _serviceRepository;
        IServiceService _serviceService;
        public ServiceController(IServiceRepository serviceRepository, IServiceService serviceService) : base (serviceRepository, serviceService)
        {
            _serviceRepository = serviceRepository;
            _serviceService = serviceService;
        }
    }
}
