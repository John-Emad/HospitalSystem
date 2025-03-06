using HospitalSystem.Domain.Entities.People;
namespace HospitalSystem.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> AddPersonAsync(Person person);
        Task<Person?>  UpdatePersonAsync(Person person);
        Task<Person?> AssignPatientId(string personId, int patientId);
        Task<Person?> GetByIdAsync(string id);
        Task<Person[]> GetAllAsync();
        Task<Person?> DeleteByIdAsync(string id);
    }
}
