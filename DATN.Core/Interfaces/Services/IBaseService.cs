using DATN.Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Interfaces.Services
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy dữ liệu entity mói
        /// </summary>
        /// <returns></returns>
        T GetNew();

        /// <summary>
        /// Danh sách đã phân trang và lọc
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<T>> GetPaging(string columns, int take, int skip, string? filter);
        Task<List<object>> GetComboboxData(string columns, int take, int skip, string? filter);
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        int GetPagingSum(string columns, int take, int skip, string? filter);

        /// <summary>
        /// Xử lí nghiệp vụ chung khi thêm mới đối tượng
        /// </summary>
        /// <param name="entity"> Đối tượng thêm mới </param>
        /// <returns> Số lượng bản ghi </returns>
        int InsertService(T entity);

        /// <summary>
        /// Xử lí nghiệp vụ khi sửa dối tượng
        /// </summary>
        /// <param name="entityId"> Id của đối tượng </param>
        /// <param name="entity"> đối tượng đã sửa </param>
        /// <returns></returns>
        int UpdateService(T entity);

        /// <summary>
        /// Xử lí nghiệp vụ khi xóa
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        List<ValidateError> DeleteService(List<Guid> param);
    }
}
