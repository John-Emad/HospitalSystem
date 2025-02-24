using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
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
        #endregion

        #region Constructors
        public TokenRepository(IConfiguration configuration, HospitalSystemDBContext hospitalSystemDBContext)
        {
            _configuration = configuration;
            _hospitalSystemDBContext = hospitalSystemDBContext;
        }
        #endregion

        #region Methods
        public Tokens Authenticate(Person person)
        {
            if (!_hospitalSystemDBContext.People.Any(x => x.Email == person.Email && x.PasswordHash == person.PasswordHash))
            {
                return null;
            }

            //We have Authenticated
            //Generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:devKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, person.Email)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
        #endregion
    }
}
