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
    public class ChuNhaService : BaseService<ChuNhaEntity>, IChuNhaService
    {
        IChuNhaRepository _ChuNhatRepository;
        public ChuNhaService(IChuNhaRepository ChuNhaRepository) : base(ChuNhaRepository)
        {
            _ChuNhatRepository = ChuNhaRepository;
        }
    }
}
