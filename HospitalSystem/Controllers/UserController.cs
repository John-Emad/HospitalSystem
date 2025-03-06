using HospitalSystem.Application.DTOs.UserDTOs;
using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;

        public UserController(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody]UserSignInDTO user)
        {
            Tokens? token = await _tokenRepository.AuthenticateAsync(user.Email, user.Password);
            if (token == null)
            {
                return BadRequest("Incorrect Email or Password");
            }
            return Ok(token);
        }
    }
}
