using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HospitalSystem.Infrastructure.Persistance.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        #region Fields
        private readonly HospitalSystemDBContext _hospitalSystemDBContext;
        private readonly UserManager<Person> _userManager;
        #endregion

        #region Constructors
        public PersonRepository(HospitalSystemDBContext hospitalSystemDBContext, UserManager<Person> userManager)
        {
            _hospitalSystemDBContext = hospitalSystemDBContext;
            _userManager = userManager;
        }
        #endregion

        #region Methods
        public async Task<Person?> AddPersonAsync(Person person)
        {
            var result = await _userManager.CreateAsync(person, password: person.PasswordHash);

            if (result.Succeeded)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

        public async Task<Person?> UpdatePersonAsync(Person person)
        {
            _hospitalSystemDBContext.People.Update(person);
            int affectedRows = await _hospitalSystemDBContext.SaveChangesAsync();
            if (affectedRows > 0)
            {
                return person; // Return the updated person if the update was successful
            }

            return null; // Return null if no changes were made
        }

        public async Task<Person?> AssignPatientId(string personId, int patientId)
        {
            Person? result = await _hospitalSystemDBContext.People.FirstOrDefaultAsync(p => p.Id == personId);
            if (result != null)
            {
                result.PatientId = patientId;
                int affectedRows = await _hospitalSystemDBContext.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    return result;
                }

            }
            return null;
        }

        public Task<Person?> DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Person[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Person?> GetByIdAsync(string id)
        {
            Person? foundPerson = await _hospitalSystemDBContext.People.FirstOrDefaultAsync<Person>(p => p.Id == id);
            if(foundPerson is null)
            {
                return null;
            }
            return foundPerson;
        }
        #endregion
    }
}
