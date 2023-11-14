using DATN.Core.Interfaces.Respositories;
using DATN.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuNhaController : ControllerBase
    {
        IConfiguration _configuration;
        IChuNhaRepository _chuNhaRepository;
        IChuNhaService _chuNhaService;
        public ChuNhaController(IConfiguration configuration, IChuNhaRepository ChuNhaRepository, IChuNhaService ChuNhaService)
        {
            _configuration = configuration;
            _chuNhaRepository = ChuNhaRepository;
            _chuNhaService = ChuNhaService;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _chuNhaRepository.Get();
                return Ok(data);

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xử lí lỗi Exception
        /// </summary>
        /// <param name="ex"></param>
        /// <returns> Thông tin lỗi Exception </returns>
        /// CreatedBy: LTTUAN (09/05/2022)
        private IActionResult HandleException(Exception ex)
        {
            var res = new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xấy ra vui lòng liên hệ MISA để được hỗ trợ",
                errorCode = "001",
                data = ex.Data
            };
            //if (ex is MISAValidateException)
                return StatusCode(400, res); //Lỗi từ server trả về 500
            //else
            //    return StatusCode(500, res);
        }
    }
}
