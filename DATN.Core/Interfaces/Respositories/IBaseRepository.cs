using System;
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
        List<T> Get(string column, string filter, int take, int skip);



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
        //int Insert(T entity);

        /// <summary>
        /// Xủ lí sửa 1 đối tượng theo id
        /// </summary>
        /// <param name="entityId"> id đối tượng cần xóa </param>
        /// <param name="entity"> bản ghi đã được sửa </param>
        /// <returns> số lượng bản ghi đã được sửa  </returns>
        //int Update(Guid entityId, T entity);

        /// <summary>
        /// Xử lí xóa 1 dối tượng theo id 
        /// </summary>
        /// <param name="entityId"> id của đối tượng cần xóa</param>
        /// <returns> số lượng bản ghi đã được xóa </returns>
        //int Delete(Guid entityId);
    }
}
