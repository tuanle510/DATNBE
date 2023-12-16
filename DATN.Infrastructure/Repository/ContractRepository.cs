using Dapper;
using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Infrastructure.Repository
{
    public class ContractRepository : BaseRepository<ContractEntity>, IContractRepository
    {
        public ContractRepository(IConfiguration configuration) : base(configuration)
        {

        }
        /// <summary>
        /// Lấy danh sách hợp đồng theo id bộ hồ sơ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ContractEntity> GetByMasterId(Guid id)
        {
            var table = this.getTableName(typeof(ContractEntity));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {table} WHERE {nameof(ContractEntity.contract_group_id)} = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<ContractEntity>(sqlQuery, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }
    }
}
