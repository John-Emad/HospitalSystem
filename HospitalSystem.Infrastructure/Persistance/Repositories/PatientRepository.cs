using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HospitalSystem.Infrastructure.Persistance.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        #region Fields
        private readonly HospitalSystemDBContext _hospitalSystemDBContext;
        #endregion

        #region Constructors
        public PatientRepository(HospitalSystemDBContext hospitalSystemDBContext)
        {
            _hospitalSystemDBContext = hospitalSystemDBContext;
        }
        #endregion

        #region Methods
        public async Task<Patient?> AddPatientAsync(Patient patient)
        {
            EntityEntry<Patient> added = await _hospitalSystemDBContext.Patients.AddAsync(patient);
            int affected = await _hospitalSystemDBContext.SaveChangesAsync();
            if (affected == 1)
            {
                // If saved to database then return
                return patient;
            }
            return null;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _hospitalSystemDBContext.Patients.ToListAsync();
        }

        public async Task<Patient?> UpdatePatientAsync(Patient patient)
        {
            _hospitalSystemDBContext.Patients.Update(patient);
            int affected = await _hospitalSystemDBContext.SaveChangesAsync();
            if (affected == 1)
            {
                // If saved to database then return
                return patient;
            }
            return null;
        }
        #endregion
    }
}
