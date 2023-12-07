using DATN.Core.Params;
using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using DATN.Core.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web03.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseBusinessController<T> : ControllerBase
    {
        IBaseRepository<T> _baseRepository;
        IBaseService<T> _baseService;
        public BaseBusinessController(IBaseRepository<T> baseRepository, IBaseService<T> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }

        #region Methods
        /// <summary>
        /// Xử lí lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpPost("list")]
        public virtual async Task<IActionResult> Get([FromBody] FilterParam param)
        {
            try
            {
                // List data đã phân trang:
                var data = await _baseService.GetPaging(param.columns, param.take, param.skip, param.filter);
                // Tổng số bản ghi khi chưa phân trang: 
                var sum = _baseService.GetPagingSum(param.columns, param.take, param.skip, param.filter);
                // trả về sữ liệu
                var res = new
                {
                    Data = data,
                    Sum = sum
                };

                return StatusCode(200, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Lấy dữ liệu entity mói
        /// </summary>
        /// <returns></returns>
        [HttpGet("new")]
        public IActionResult GetNew()
        {
            try
            {
                var entitties = _baseService.GetNew();
                return Ok(entitties);
            }   
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí lấy dữ liệu về theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            try
            {
                var entitties = _baseRepository.GetById(entityId);
                return Ok(entitties);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] T entity)
        {
            try
            {
                var res = _baseService.InsertService(entity);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí sửa đối tượng 
        /// </summary>
        /// <param name="entityId"> Id của đôi tượng </param>
        /// <param name="entity"> Dữ liệu mới </param>
        /// <returns></returns>
        //[HttpPut("{entityId}")]
        //public virtual IActionResult Put(Guid entityId, [FromBody] T entity)
        //{
        //    try
        //    {
        //        var res = _baseService.UpdateService(entityId, entity);
        //        return StatusCode(200, res);
        //    }
        //    catch (Exception ex)
        //    {
        //        return HandleException(ex);
        //    }
        //}

        /// Xử lí xóa nhiều
        /// </summary>
        /// <param name="fixedAssetIdList"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromBody] List<Guid> param)

        {
            var res = _baseService.DeleteService(param);
            return Ok(res);
        }

        /// <summary>
        /// Xử lí lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpPost("combobox")]
        public virtual async Task<IActionResult> GetComboboxData([FromBody] FilterParam param)
        {
            try
            {
                // List data đã phân trang:
                var data = await _baseService.GetPaging(param.columns, param.take, param.skip, param.filter);
                return StatusCode(200, data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion


        /// <summary>
        /// Xử lí lỗi Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns> Thông tin lỗi Exception </returns>
        /// CreatedBy: LTTUAN (09/05/2022)
        protected IActionResult HandleException(Exception ex)
        {
            var res = new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xấy ra vui lòng liên hệ LTTUAN để được hỗ trợ",
                errorCode = "001",
                data = ex.Data
            };
            if (ex is BusinessException)
                return StatusCode(200, res); //Lỗi từ server trả về 500
            else
                return StatusCode(500, res);
        }
    }
}