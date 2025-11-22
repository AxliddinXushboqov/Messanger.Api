using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Messanger.Api.Models.Foundations.Users;
using Messanger.Api.Models.Orchestrations;
using Microsoft.IdentityModel.Tokens;

namespace Messanger.Api.Brokers.Tokens
{
    public class TokenBroker : ITokenBroker
    {
        public UserToken GenerateJWTToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("PhoneNumber",user.PhoneNumber),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };

            var securityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6AD2EF4v89d4v9dse98df784DE-Ada98f4as894B2C-48sd4v98s7v98sd78dg8d49g"));

            var signingCred =
                new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: signingCred
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new UserToken
            {
                Token = tokenString,
            };
        }
    }
}