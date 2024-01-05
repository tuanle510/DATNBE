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
    public class PaymentServiceRepository : BaseRepository<PaymentServiceEntity>, IPaymentServiceRepository
    {
        public PaymentServiceRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public List<PaymentServiceEntity> GetByMasterId(Guid id)
        {
            var table = this.getTableName(typeof(PaymentServiceEntity));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {table} WHERE {nameof(PaymentServiceEntity.contract_id)} = @id ORDER BY {nameof(PaymentServiceEntity.expected_payment_date)}";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<PaymentServiceEntity>(sqlQuery, param: parameters);

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
    }
}
