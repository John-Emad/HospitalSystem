using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Application.Interfaces
{
    public interface IPatientService
    {
        Task<Patient?> AddPatientAsync(Patient patient);
        Task<Patient?> UpdatePatientAsync(Patient patient);
        Task<List<Patient>> GetAllPatientsAsync();
    }
}
