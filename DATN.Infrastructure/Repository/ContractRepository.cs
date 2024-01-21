using Dapper;
using DATN.Core.Entities;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Params;
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

        /// <summary>
        /// màn này không check 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public override bool CheckArise(Guid param)
        {
            return false;
        }

        protected override string? buildWhere(List<Filter> filter, DynamicParameters param)
        {
            var where = new StringBuilder();
            if (filter != null)
            {
                for (int i = 0; i < filter.Count; i++)
                {
                    if (filter[i].field == "lessor_name")
                    {
                        where.Append($"(({nameof(ContractEntity.owner_name)} like CONCAT('%',@{filter[i].field},'%') and ({nameof(ContractEntity.contract_type)} = 'THUÊ Chủ nhà - Khách' OR {nameof(ContractEntity.contract_type)} = 'THUÊ Chủ nhà - Công ty')) OR ");
                        where.Append($"({nameof(ContractEntity.company_name)} like CONCAT('%',@{filter[i].field},'%') and {nameof(ContractEntity.contract_type)} = 'THUÊ Công ty - Khách')) ");
                    } 
                    else if (filter[i].field == "renter_name")
                    {
                        where.Append($"(({nameof(ContractEntity.client_name)} like CONCAT('%',@{filter[i].field},'%') and ({nameof(ContractEntity.contract_type)} = 'THUÊ Chủ nhà - Khách' OR {nameof(ContractEntity.contract_type)} = 'THUÊ Công ty - Khách')) OR ");
                        where.Append($"({nameof(ContractEntity.company_name)} like CONCAT('%',@{filter[i].field},'%') and {nameof(ContractEntity.contract_type)} = 'THUÊ Chủ nhà - Công ty')) ");
                    }
                    else
                    {
                        switch (filter[i].op)
                        {
                            case "=":
                                where.Append($"{filter[i].field} = @{filter[i].field}");
                                break;
                            default:
                                where.Append($"{filter[i].field} like CONCAT('%',@{filter[i].field},'%')");
                                break;
                        }
                    }
                    if (i < filter.Count - 1)
                    {
                        where.Append(" AND ");
                    }
                    param.Add($"@{filter[i].field}", filter[i].value);
                }
            }
            return where.ToString();
        }

    }
}
