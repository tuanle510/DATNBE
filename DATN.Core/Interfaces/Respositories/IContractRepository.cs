using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Interfaces.Respositories
{
    public interface IContractRepository : IBaseRepository<ContractEntity>
    {
        /// <summary>
        /// Lấy danh sách hợp đồng theo id bộ hồ sơ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ContractEntity> GetByMasterId(Guid id);
    }
}
