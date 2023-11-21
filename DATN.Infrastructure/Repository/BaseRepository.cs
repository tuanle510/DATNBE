using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;
using System.Text.RegularExpressions;
using System.Text;
using DATN.Core.Attributes;

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
            var table = this.getTableName(typeof(T));
            //var tableName = Regex.Replace(typeof(T).Name.ToLower(), "entity", string.Empty);
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlCommand = $"SELECT * FROM { table }";

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<T>(sqlCommand);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public T GetById(Guid entityId)
        {
            var table = this.getTableName(typeof(T));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {table} WHERE {table}.id = @entityId";
            var parameters = new DynamicParameters();
            parameters.Add("@entityId", entityId);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.QueryFirstOrDefault<T>(sqlQuery, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities;
        }

        /// <summary>
        /// Lấy tên table theo custom Attribute
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string getTableName(Type type)
        {
            TableName? attribute = Attribute.GetCustomAttribute(type, typeof(TableName)) as TableName;
            return attribute != null ? attribute.Name : "";
        }
    }
}
