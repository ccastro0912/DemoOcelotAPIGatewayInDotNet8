using Identity_ms.ViewModels;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Authentication;

namespace Identity_ms.JWT
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly List<UserViewModel> users = new()
        {
            new UserViewModel
            {
                user_name = "admin",
                password = "admin",
                role = RoleEnum.Admin,
            },
            new UserViewModel
            {
                user_name = "sop",
                password = "sop",
                role = RoleEnum.User,
            }
        };

        public string? GenerateAuthToken(LoginViewModel login)
        {
            var user = users.FirstOrDefault(u => u.user_name == login.user_name
                                               && u.password == login.password);
            if (user is null) return null;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("L+fl4OzW1G9hbKZBq4NfNw5f3H+B2PXnXeztE4nX5V8="));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expirationTimeStamp = DateTime.Now.AddMinutes(5);
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Name, user.user_name),
                new ("role", user.role.ToString()),
                new ("scope", string.Join(" ", "scope1"))
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5002",
                claims: claims,
                expires: expirationTimeStamp,
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            //return new AuthenticationToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
        }
    }
}
