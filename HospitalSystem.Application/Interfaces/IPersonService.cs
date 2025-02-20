using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Person?> CreateAsync(Person person);
        Task<Person?> GetByIdAsync(string id);
        Task<Person[]> GetAllAsync();
        Task<Person?> Update(Person person);
        Task<Person?> DeleteByIdAsync(string id);
    }
}
