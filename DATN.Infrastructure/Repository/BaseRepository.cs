using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;
using System.Text.RegularExpressions;
using System.Text;

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
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            // Khai báo thông tin database:
            _connectionString = _configuration.GetConnectionString("LTTUAN");
            // Khỏi tạo kết nối đến database --> sử dụng mySqlConnector
            _sqlConnection = new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Xử lí lấy dữ liệu 
        /// </summary>
        /// <returns></returns>
        public List<T> Get(string column, string? filter, int take, int skip)
        {
            var table = this.ConvertToSnakeCase(typeof(T).Name);
            //var tableName = Regex.Replace(typeof(T).Name.ToLower(), "entity", string.Empty);
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlCommand = $"SELECT * FROM { table }";

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<T>(sqlCommand);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }
        private string ConvertToSnakeCase(string input)
        {
            StringBuilder sb = new StringBuilder();
            var entityText = "Entity";
            if (input.EndsWith(entityText))
            {
                input = Regex.Replace(input, entityText, string.Empty);
            }

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (i > 0 && char.IsUpper(currentChar))
                {
                    // Nếu ký tự là viết hoa và không phải ký tự đầu tiên
                    // thì thêm dấu '_' trước khi thêm ký tự viết thường
                    sb.Append('_').Append(char.ToLower(currentChar));
                }
                else if (currentChar != '_')
                {
                    // Bỏ qua dấu '_' nếu có trong chuỗi ban đầu
                    sb.Append(currentChar);
                }
            }

            return sb.ToString().ToLower();
        }

        public T GetById(Guid entityId)
        {
            var table = this.ConvertToSnakeCase(typeof(T).Name);
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {table} WHERE {table}.id = @entityId";
            var parameters = new DynamicParameters();
            parameters.Add("@entityId", entityId);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.QueryFirstOrDefault<T>(sqlQuery, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities;
        }
    }
}
