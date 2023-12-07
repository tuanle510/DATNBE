using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Services
{
    public class OwnerService : BaseService<OwnerEntity>, IOwnerService
    {
        IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository) : base(ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
    }
}
