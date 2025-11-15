using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using backTOT.Data;
using backTOT.Dto;
using backTOT.Entities;
using backTOT.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backTOT.Services.Auth
{
    public class AuthService
    {
        private DataContext _context;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;
        private IMapper _mapper;
        public AuthService(DataContext context, IConfiguration config,EmailService emailService,IMapper mapper)
        {
            _context = context;
            _config = config;
            _emailService = emailService;
            _mapper = mapper;
        }
        // Hàm tạo JWT Access Token
        private string GenerateJwtToken(Users user)
        {
            // lấy role
            var roles = _context.UserRoles.
                Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.Role.RoleName);
            // Lấy danh sách role của user (nếu có dùng bảng UserRoles)
            var permissions = _context.RolePermissions
                .Where(rp => rp.Role.UserRoles.Any(ur => ur.UserId == user.Id))
                .Select(rp => rp.Permission.Name)
                .Union
                     (
                    _context.UserPermissions.
                    Where(up => up.UserId == user.Id)
                    .Select(up => up.Permission.Name)
                     )
                 .Distinct()
                 .ToList();
            // Tạo danh sách claims
            var claims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim("name", user.FullName),
                    new Claim("userId", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            // thêm role 
            foreach(var rol in roles)
            {
                claims.Add(new Claim("role", rol ?? string.Empty));
            }
            // Thêm claim Role vào token
            foreach (var perm in permissions)
            {
                claims.Add(new Claim("permission", perm ?? string.Empty));
            }
            // Khóa bí mật trong appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            // Thuật toán chữ ký HS256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Tạo JWT token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            // tạo token dạng chuỗi
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Hàm tạo Refresh Token (chuỗi random an toàn)
        private string GenerateRefreshToken(Users user)
        {
            var claims = new List<Claim>
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:RefreshKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Làm mới Access Token
        public AuthResponse RefreshToken(string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:RefreshKey"]));
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, //check hết hạn refresh token
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Audience"],
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                };
                // Xác thực token
                var principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out var validatedToken);

                // Lấy userId từ claims
                var userId = principal.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
                if (userId == null) return null;

                var user = _context.Users.Find(int.Parse(userId));
                if (user == null) return null;

                // Tạo access token mới
                var newAccessToken = GenerateJwtToken(user);

                return new AuthResponse
                {
                    AccessToken = newAccessToken,
                    RefreshToken = refreshToken, // dùng lại refresh token cũ
                    AccessTokenExpiration = DateTime.UtcNow.AddMinutes(30),
                    RefreshTokenExpiration = DateTime.UtcNow.AddDays(30)
                };
            }
            catch
            {
                // Refresh token hết hạn hoặc sai → bắt đăng nhập lại
                return null;
            }
        }

        public AuthResponse UsersLogin(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(p => p.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;
            var accessToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken(user);
            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                AccessTokenExpiration = DateTime.UtcNow.AddMinutes(30),
                RefreshTokenExpiration = DateTime.UtcNow.AddDays(30)
            };
        }

        public bool UsersSignIn(Users users)
        {
            users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);
            _context.Users.Add(users);
            return Save();
        }
        public async Task<bool> ChangePasswordAsync(Guid userId, string oldPassword, string newPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return false;

            // Kiểm tra mật khẩu cũ
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password)) return false;

            // Hash và cập nhật mật khẩu mới
            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _context.Users.Update(user);

            var result = Save();
            if (result)
            {
                try
                {
                    string subject = "Thông báo đổi mật khẩu";
                    string body = $@"
                        <h2>Xin chào {user.FullName},</h2>
                        <p>Bạn vừa đổi mật khẩu thành công lúc <b>{DateTime.Now:dd/MM/yyyy HH:mm}</b>.</p>
                        <p>Nếu bạn không thực hiện hành động này, vui lòng liên hệ ngay với bộ phận hỗ trợ.</p>
                        <br/>
                        <p>-- Hệ thống của bạn</p>
                    ";
                    await _emailService.SendEmailAsync(user.Email, subject, body);
                    Console.WriteLine("✅ Email sent to " + user.Email);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Send email failed: " + ex.Message);
                    throw; // để bubble lên controller, bạn sẽ thấy 500 Internal Server Error
                }
            }
            return result;
        }
        public async Task<bool> RegisterUserAsync(UserDto userDto)
        {
            if (userDto == null) return false;

            // Check email đã tồn tại chưa
            if (_context.Users.Any(u => u.Email == userDto.Email))
                return false;

            var user = _mapper.Map<Users>(userDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            // Tạo token xác thực
            user.VerificationToken = Guid.NewGuid().ToString();
            user.VerificationTokenExpiry = DateTime.UtcNow.AddHours(1);
            user.IsVerified = false;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Gửi mail xác thực
            string confirmLink = $"https://localhost:7041/api/Auth/confirm?token={user.VerificationToken}";
            string subject = "Xác nhận đăng ký tài khoản";
            string body = $@"
            <h2>Xin chào {user.FullName},</h2>
            <p>Bạn đã đăng ký tài khoản, vui lòng nhấn vào link sau để kích hoạt:</p>
            <a href='{confirmLink}'>Xác nhận tài khoản</a>
            <br/><br/>
            <p>Link sẽ hết hạn sau 1 giờ.</p>
        ";
            await _emailService.SendEmailAsync(user.Email, subject, body);

            return true;
        }

        public async Task<bool> ConfirmEmailAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationToken == token);

            if (user == null || user.VerificationTokenExpiry < DateTime.UtcNow)
                return false;

            user.IsVerified = true;
            user.VerificationToken = null;
            user.VerificationTokenExpiry = null;

            await _context.SaveChangesAsync();

            return true;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
