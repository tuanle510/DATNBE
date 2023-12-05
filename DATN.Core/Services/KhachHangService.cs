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
    public class KhachHangService : BaseService<KhachHangEntity>, IKhachHangService
    {
        IKhachHangRepository _KhachHangtRepository;
        public KhachHangService(IKhachHangRepository KhachHangRepository) : base(KhachHangRepository)
        {
            _KhachHangtRepository = KhachHangRepository;
        }
    }
}
