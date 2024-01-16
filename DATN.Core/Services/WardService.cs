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
    public class WardService : BaseService<WardEntity>, IWardService
    {
        IWardRepository _wardRepository;
        public WardService(IWardRepository wardRepository) : base(wardRepository)
        {
            _wardRepository = wardRepository;
        }
    }
}
