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
        IOwnerRepository _ChuNhatRepository;
        public OwnerService(IOwnerRepository ChuNhaRepository) : base(ChuNhaRepository)
        {
            _ChuNhatRepository = ChuNhaRepository;
        }
    }
}
