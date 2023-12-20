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
    public class PaymentTransactionRepository : BaseRepository<PaymentTransactionEntity>, IPaymentTransactionRepository
    {
        public PaymentTransactionRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<PaymentTransactionEntity> GetByMasterId(Guid id)
        {
            var table = this.getTableName(typeof(PaymentTransactionEntity));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {table} WHERE {nameof(PaymentTransactionEntity.contract_id)} = @id ORDER BY {nameof(PaymentTransactionEntity.start_date)}";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<PaymentTransactionEntity>(sqlQuery, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }
    }
}
