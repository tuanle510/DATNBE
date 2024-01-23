using Dapper;
using DATN.Core.Entities;
using DATN.Core.Params;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DATN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //IAuthRepository<AuthEntiry> _authRepository;
        //IAuthService<AuthEntiry> _authService;
        //public AuthController(IAuthRepository<AuthEntiry> authRepository, IAuthService<AuthEntiry> authService) : base(authRepository, authService)
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
        private readonly IConfiguration _configuration;
        readonly string _connectionString = string.Empty;
        protected MySqlConnection _sqlConnection;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;// Khai báo thông tin database:
            _connectionString = _configuration.GetConnectionString("LTTUAN");
            // Khỏi tạo kết nối đến database --> sử dụng mySqlConnector
            _sqlConnection = new MySqlConnection(_connectionString);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginParam login)
        {
            try
            {
                var user = AuthenticateUser(login.email, login.password);
                if (user == null)
                {
                    return BadRequest();
                }
                string token = CreateToken(user);
                return Ok(token);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Tạo token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(AuthEntiry user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, user.user_name),
                //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("user_id", user.user_id.ToString()),
                new Claim("email", user.email)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        /// <summary>
        /// Đăng xuất
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
            var sb = $"SELECT * FROM auth where email = @email and password = @password";
            var parameters = new DynamicParameters();
            parameters.Add($"@email", email);
            parameters.Add($"@password", password);
            var entities = _sqlConnection.QueryFirstOrDefault<AuthEntiry>(sb, param: parameters);

            if (entities != null)
            {
                return entities;
            }
            else
            {
                return null;
            }
        }
    }
}
