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
    public class CanHoService : BaseService<CanHoEntity>, ICanHoService
    {
        ICanHoRepository _CanHoRepository;
        public CanHoService(ICanHoRepository CanHoRepository) : base(CanHoRepository)
        {
            _CanHoRepository = CanHoRepository;
        }
    }
}
