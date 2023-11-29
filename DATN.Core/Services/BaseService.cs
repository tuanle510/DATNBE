using DATN.Core.Attributes;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Danh sách đã phân trang và lọc
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> GetPaging(string columns, int take, int skip, string? filter)
        {
            return _baseRepository.GetPaging(columns, take, skip, filter);
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
            return _baseRepository.GetPagingSum(columns, take, skip, filter);
        }

        /// <summary>
        /// Lấy dữ liệu entity mói
        /// </summary>
        /// <returns></returns>
        public T GetNew()
        {
            Type type = typeof(T);
            T entity = (T)Activator.CreateInstance(type);
            var properties = typeof(T).GetProperties();
            var prop = type.GetProperties().Where(e => e.IsDefined(typeof(PrimaryKey))).FirstOrDefault();
            prop.SetValue(entity, Guid.NewGuid());
            return entity;
        }

        /// <summary>
        /// Xử lí nghiệp vụ chung khi thêm mới đối tượng
        /// </summary>
        /// <param name="entity"> Đối tượng thêm mới </param>
        /// <returns> Số lượng bản ghi </returns>
        public int InsertService(T entity)
        {
            // Nếu không có lỗi thì thực hiện insert
            return _baseRepository.Insert(entity);
        }

        public int UpdateService(Guid entityId, T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Xử lí nghiệp vụ khi xóa
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int DeleteService(List<Guid> param)
        {
            // Nếu không có lỗi thì thực hiện insert
            return _baseRepository.Delete(param);
        }
    }
}
