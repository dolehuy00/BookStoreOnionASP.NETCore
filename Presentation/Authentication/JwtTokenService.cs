using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Web.Service
{
    public class JwtTokenService
    {
        private readonly IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GetIdFromAccessToken(HttpContext context)
        {
            // Lấy token từ tiêu đề Authorization của HttpContext
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                // Giải mã token thành một đối tượng JwtSecurityToken
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken != null)
                {
                    // Lấy các claims từ token
                    var claims = jwtToken.Claims;

                    // Tìm claim có tên là "Id" và lấy giá trị của nó
                    var userIdClaim = claims.FirstOrDefault(c => c.Type == "Id");

                    if (userIdClaim != null)
                    {
                        return userIdClaim.Value;
                    }
                }
            }
            return string.Empty;
        }

        public string GenerateAccessToken(string id, string roleName)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _config["AccessTokenJwt:Subject"]!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", id),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AccessTokenJwt:Key"]!));
            var signIng = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["AccessTokenJwt:ExpiresMinutes"]!)),
                signingCredentials: signIng
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

