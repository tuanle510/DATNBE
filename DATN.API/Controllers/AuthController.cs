using DATN.Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //IAuthRepository<AuthEntiry> _authRepository;
        //IAuthService<AuthEntiry> _authService;
        //public AuthController(IAuthRepository<AuthEntiry> authRepository, IAuthService<AuthEntiry> authService)
        //{
        //    _authRepository = authRepository;
        //    _authService = authService;
        //}
        /// <summary>
        /// Xử lí sự kiện login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //POST api/<UsersController>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthEntiry login)
        {
            try
            {
                var user = AuthenticateUser(login.email, login.password);
                if (user == null)
                {
                    return BadRequest();
                }

                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Email, "oklea"),
                    //new Claim(ClaimTypes.Email, user.email),
                    //new Claim("FirstName", user.FirstName),
                    //new Claim("LastName", user.LastName),
                    //new Claim("Username", user.Username),

                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity)
                    );

                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return Ok();
        }

        /// <summary>
        /// Kiểm tra email và password có hợp lệ khong
        /// </summary>
        /// <param name="Email"> Email người dùng nhập </param>
        /// <param name="Password"> Password ngườu dùng nhập </param>
        /// <returns> Nếu hợp lệ - Thông tin user đã đang nhập, Nếu không hợp lệ - trả về null  </returns>
        private AuthEntiry AuthenticateUser(string email, string password)
        {
            // TODO: mã hóa password, làm thêm task (bất đồng độ)
            // băm hash256, check key 
            if (email == "user@mail" && password == "12345")
            {
                return new AuthEntiry()
                {
                    //Email = "user@mail",
                    //FirstName = "Lê",
                    //LastName = "Tuấn",
                    //Username = "Tit"
                };
            }
            else
            {
                return null;
            }
        }
    }
}
