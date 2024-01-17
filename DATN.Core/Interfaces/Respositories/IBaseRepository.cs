using DATN.Core.Params;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Core.Interfaces.Respositories
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Xử lí lấy dữ liệu 
        /// </summary>
        /// <returns> Lấy tất cả bản ghi </returns>
        List<T> Get(string columns, int take, int skip, string? filter);

        /// <summary>
        /// Danh sách đã phân trang và lọc
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<T>> GetPaging(string columns, int take, int skip, List<Filter>? filter);

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        int GetPagingSum(string columns, int take, int skip, List<Filter>? filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<object>> GetComboboxData(string columns, int take, int skip, List<Filter>? filter);


        /// <summary>
        /// Xử lí lấy dữ liệu theo ID
        /// </summary>
        /// <param name="entityId"> id của dữ liện cần lấy </param>
        /// <returns> Đối tượng lấy về theo id </returns>
        T GetById(Guid entityId);

        /// <summary>
        /// Xử lí thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Số lượng bản ghi đã được thêm </returns>
        int Insert(T entity);

        /// <summary>
        /// Xủ lí sửa 1 đối tượng theo id
        /// </summary>
        /// <param name="entityId"> id đối tượng cần xóa </param>
        /// <param name="entity"> bản ghi đã được sửa </param>
        /// <returns> số lượng bản ghi đã được sửa  </returns>
        int Update(T entity);

        /// <summary>
        /// Xử lí xóa 1 dối tượng theo id 
        /// </summary>
        /// <param name="entityId"> id của đối tượng cần xóa</param>
        /// <returns> số lượng bản ghi đã được xóa </returns>
        int Delete(Guid param);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        int DeleteByMasterId(Guid param);

        /// <summary>
        ///  Lấy danh sách theo master
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idString">tên key của master</param>
        /// <returns></returns>
        List<object> GetByMasterId(Guid id, string idString);

        bool CheckArise(Guid param);
    }
}
