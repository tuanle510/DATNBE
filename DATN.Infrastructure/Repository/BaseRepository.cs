using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;

namespace DATN.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        /// <summary>
        /// Xử lí kết nối với database 
        /// </summary>
        IConfiguration _configuration;
        readonly string _connectionString = string.Empty;
        protected MySqlConnection _sqlConnection;
        string _tableName;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            // Khai báo thông tin database:
            _connectionString = _configuration.GetConnectionString("LTTUAN");
            // Khỏi tạo kết nối đến database --> sử dụng mySqlConnector
            _sqlConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(T).Name;
        }

        /// <summary>
        /// Xử lí lấy dữ liệu 
        /// </summary>
        /// <returns></returns>
        public List<T> Get()
        {
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            //var sqlCommand = $"SELECT * FROM {_tableName}";
            var sqlCommand = $"SELECT * FROM chu_nha";

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<T>(sqlCommand);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }
    }
}
