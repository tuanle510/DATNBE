using DATN.Core.Attributes;
using DATN.Core.Exceptions;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using DATN.Core.Params;
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
        public async Task<List<T>> GetPaging(string columns, int take, int skip, string? filter)
        {
            return await _baseRepository.GetPaging(columns, take, skip, filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<object>> GetComboboxData(string columns, int take, int skip, string? filter)
        {
            return await _baseRepository.GetComboboxData(columns, take, skip, filter);
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
            foreach (var prop in type.GetProperties().Where(e => e.PropertyType == typeof(Guid) || e.PropertyType == typeof(Guid?)))
            {
                if (prop.IsDefined(typeof(PrimaryKey)))
                {
                    prop.SetValue(entity, Guid.NewGuid());
                }
                else
                {
                    prop.SetValue(entity, null);
                }
            }
            return entity;
        }

        /// <summary>
        /// Xử lí nghiệp vụ chung khi thêm mới đối tượng
        /// </summary>
        /// <param name="entity"> Đối tượng thêm mới </param>
        /// <returns> Số lượng bản ghi </returns>
        public int InsertService(T entity)
        {
            // Gán giá trị mới cho thuộc tính created_date
            PropertyInfo? propInfo = typeof(T).GetProperty("created_date");
            if (propInfo != null && propInfo.CanWrite)
            {
                propInfo.SetValue(entity, DateTime.Now);
            }
            // Nếu không có lỗi thì thực hiện insert
            return _baseRepository.Insert(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateService(T entity)
        {
            // Gán giá trị mới cho thuộc tính created_date
            PropertyInfo? propInfo = typeof(T).GetProperty("modified_date");
            if (propInfo != null && propInfo.CanWrite)
            {
                propInfo.SetValue(entity, DateTime.Now);
            }
            // Nếu không có lỗi thì thực hiện sửa
            return _baseRepository.Update(entity);
        }

        /// <summary>
        /// Xử lí nghiệp vụ khi xóa
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<ValidateError> DeleteService(List<Guid> param)
        {
            var errList = new List<ValidateError>();
            for (int i = 0; i < param.Count; i++)
            {
                try
                {
                    this.DeleteAsync(param[i]);
                }
                catch (BusinessException ex)
                {
                    errList.Add(
                        new ValidateError
                        {
                            Index = i,
                            Data = ex.ErrorData,
                            Code = ex.ErrorCode,
                        }
                     );
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return errList;
        }

        private void DeleteAsync(Guid guid)
        {
            // validate trước khi xóa
            this.validateBeforeDelete(guid);
            // Sự kiện xóa
            _baseRepository.Delete(guid);

            this.deleteDetail(guid);
        }

        /// <summary>
        /// thò ra hàm xóa detail
        /// </summary>
        /// <param name="guid"></param>
        public virtual void deleteDetail(Guid guid)
        {
        }

        private void validateBeforeDelete(Guid guid)
        {
            var isArise = _baseRepository.CheckArise(guid);
            // Nếu có phát sinh thì không xóa được
            if (isArise)
            {
                throw new BusinessException()
                {
                    ErrorMsg = "VALIDATE",
                    ErrorCode = "VALIDATE",
                    ErrorData = new
                    {
                        id = guid
                    }
                };
            }
        }
    }
}
