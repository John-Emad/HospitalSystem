using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Person?> AddPersonAsync(Person person);
        Task<Person?> UpdatePersonAsync(Person person);
        Task<Person?> AssignPatientId(string personId, int patientId);
        Task<Person?> GetByIdAsync(string id);
        Task<Person[]> GetAllPeopleAsync();
        Task<Person?> DeleteByIdAsync(string id);
    }
}
