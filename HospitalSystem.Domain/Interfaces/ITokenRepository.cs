using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Domain.Interfaces
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Person person);
    }
}
