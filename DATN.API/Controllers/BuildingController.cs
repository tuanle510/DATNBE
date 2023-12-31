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
    public class BuildingController : BaseBusinessController<BuildingEntity>
    {
        IBuildingRepository _buildingRepository;
        IBuildingService _buildingService;
        public BuildingController(IBuildingRepository buildingRepository, IBuildingService buildingService) : base(buildingRepository, buildingService)
        {
            _buildingRepository = buildingRepository;
            _buildingService = buildingService;
        }
    }
}
