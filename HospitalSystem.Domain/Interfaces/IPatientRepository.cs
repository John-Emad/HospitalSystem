using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> AddPatientAsync(Patient patient);
        Task<Patient?> UpdatePatientAsync(Patient patient);
        Task<List<Patient>> GetAllPatientsAsync();
    }
}
