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
    public class ClientController : BaseBusinessController<ClientEntity>
    {
        IClientRepository _clientRepository;
        IClientService _clientService;
        public ClientController(IClientRepository clientRepository, IClientService clientService) : base(clientRepository, clientService)
        {
            _clientRepository = clientRepository;
            _clientService = clientService;
        }
    }
}
    