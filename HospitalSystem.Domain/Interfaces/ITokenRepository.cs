using HospitalSystem.Domain.Entities;

namespace HospitalSystem.Domain.Interfaces
{
    public interface ITokenRepository
    {
        Task<Tokens?> AuthenticateAsync(string Email, string Password);
    }
}
