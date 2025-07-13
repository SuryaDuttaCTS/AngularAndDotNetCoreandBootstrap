using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularApp1.Server.Repository
{
    public class TokenSQLRepository : ITokenSQLRepository
    {
        private readonly IConfiguration configuration;

        public TokenSQLRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJWTtoken(IdentityUser user, List<string> Roles)
        {
            //Create a claims from the roles
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Email, user.Email)
               
            };
            claims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //use the claims to create te Jwt security token parameters

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])); // Use a secure key

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );
            //Return the tokens
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
