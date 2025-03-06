using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace HospitalSystem.Infrastructure.Persistance.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private readonly HospitalSystemDBContext _hospitalSystemDBContext;
        private readonly UserManager<Person> _userManager;
        #endregion

        #region Constructors
        public TokenRepository(IConfiguration configuration,
            HospitalSystemDBContext hospitalSystemDBContext,
            UserManager<Person> userManager)
        {
            _configuration = configuration;
            _hospitalSystemDBContext = hospitalSystemDBContext;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task<Tokens?> AuthenticateAsync(string Email, string Password)
        {
            var result = await _userManager.FindByEmailAsync(Email);

            if (result is not null && await _userManager.CheckPasswordAsync(result, Password))
            {
                // We have Authenticated
                //Generate JSON Web Token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:devKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, Email)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Tokens { Token = tokenHandler.WriteToken(token) };
            }
            //if (!_hospitalSystemDBContext.People.Any(x => x.Email == Email && x.PasswordHash == Password))
            //{
            //    return null;
            //}
            return null;

        }
        #endregion
    }
}
