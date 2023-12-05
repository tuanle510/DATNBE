﻿using DATN.Core.Interfaces.Respositories;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Dapper;
using System.Text.RegularExpressions;
using System.Text;
using DATN.Core.Attributes;
using System.Reflection;
using DATN.Core.Params;
using System.Collections;

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
        public List<T> Get(string columns, int take, int skip, string? filter)
        {
            var table = this.getTableName(typeof(T));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sb = $"SELECT * FROM { table }";

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.Query<T>(sb);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }

        /// <summary>
        /// Danh sách đã phân trang và lọc
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<T>> GetPaging(string columns, int take, int skip, string? filter)
        {
            var table = this.getTableName(typeof(T));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sb = $"SELECT { columns } FROM { table }";
            sb += $" LIMIT @take";
            if (skip > 0)
            {
                sb += $" OFFSET @skip";
            }
            var parameters = new DynamicParameters();
            parameters.Add("@take", take);
            parameters.Add("@skip", skip);

            // Thực hiện câu truy vấn:
            var entities = await _sqlConnection.QueryAsync<T>(sb, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities.ToList();
        }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int GetPagingSum(string columns, int take, int skip, string? filter)
        {
            var table = this.getTableName(typeof(T));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sb = $"SELECT COUNT( * ) AS total FROM { table }";

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.QueryFirstOrDefault<TotalParam>(sb);

            // Trả về dữ liệu dạng List:
            return entities?.total ?? 0;
        }

        /// <summary>
        /// Lấy theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public T GetById(Guid entityId)
        {
            var table = this.getTableName(typeof(T));
            var key = this.getPrimaryKey(typeof(T));
            // Thực hiện khai báo câu lệnh truy vấn SQL:
            var sqlQuery = $"SELECT * FROM {table} WHERE {key} = @entityId";
            var parameters = new DynamicParameters();
            parameters.Add("@entityId", entityId);

            // Thực hiện câu truy vấn:
            var entities = _sqlConnection.QueryFirstOrDefault<T>(sqlQuery, param: parameters);

            // Trả về dữ liệu dạng List:
            return entities;
        }

        /// <summary>
        /// Xử lí thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Số lượng bản ghi đã được thêm </returns>
        public int Insert(T entity)
        {
            // Khỏi tạo câu lệnh 
            var columnNames = "";
            var columnParams = "";
            var table = this.getTableName(typeof(T));
            // Lấy ra tất cả các properties của class:
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                // Tên của prop:
                var propName = prop.Name;
                // Bồ sung cột hiện tại vào chuỗi câu truy vấn cột dữ liệu:
                columnNames += $" {propName},";
                columnParams += $"@{propName},";
            }
            // Xóa dấu phẩy cuối cùng của chuỗi
            columnNames = columnNames.Remove(columnNames.Length - 1, 1);
            columnParams = columnParams.Remove(columnParams.Length - 1, 1);
            var sql = $"INSERT INTO {table}({columnNames}) VALUES ({columnParams})";
            var res = _sqlConnection.Execute(sql, param: entity);
            return res;
        }

        /// <summary>
        /// Xử lí xóa
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Delete(Guid param)
        {
            var table = this.getTableName(typeof(T));
            var key = this.getPrimaryKey(typeof(T));
            var parameters = new DynamicParameters();
            parameters.Add($"@{key}", param);
            var sqlQuerry = $"DELETE FROM {table} WHERE {key} = @{key}";
            var res = _sqlConnection.Execute(sqlQuerry, param: parameters);
            return res;
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

        /// <summary>
        /// Lấy khóa chính
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string? getPrimaryKey(Type type)
        {
            var props = type.GetProperties().Where(e => e.IsDefined(typeof(PrimaryKey)));
            return props?.FirstOrDefault()?.Name;
        }

        public bool CheckArise(Guid param)
        {
            var sqlQuerry = $"SELECT * FROM chu_nha";
            var res = _sqlConnection.Query<object>(sqlQuerry);
            return false;
        }
    }
}
