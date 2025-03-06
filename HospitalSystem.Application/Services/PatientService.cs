using HospitalSystem.Application.Interfaces;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        #region Fields
        private readonly IPatientRepository _patientRepository;
        #endregion

        #region Constructors
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        #endregion

        #region Methods
        public async Task<Patient?> AddPatientAsync(Patient patient)
        {
            // Implement the logic to add a patient
            return await _patientRepository.AddPatientAsync(patient);
        }

        public Task<List<Patient>> GetAllPatientsAsync()
        {
            return _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient?> UpdatePatientAsync(Patient patient)
        {
            return await _patientRepository.UpdatePatientAsync(patient);
        }
        #endregion
    }
}
