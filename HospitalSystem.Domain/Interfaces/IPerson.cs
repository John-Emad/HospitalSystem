using HospitalSystem.Domain.Entities.People;
namespace HospitalSystem.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> CreateAsync(Person person);
        Task<Person?> GetByIdAsync(string id);
        Task<Person[]> GetAllAsync();
        Task<Person?> Update(Person person);
        Task<Person?> DeleteByIdAsync(string id);
    }
}
