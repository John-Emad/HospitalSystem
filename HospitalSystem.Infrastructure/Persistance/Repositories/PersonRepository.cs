using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HospitalSystem.Infrastructure.Persistance.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly HospitalSystemDBContext _hospitalSystemDBContext;

        public PersonRepository(HospitalSystemDBContext hospitalSystemDBContext)
        {
            this._hospitalSystemDBContext = hospitalSystemDBContext;
        }

        public async Task<Person?> CreateAsync(Person person)
        {
            EntityEntry<Person> added = await _hospitalSystemDBContext.People.AddAsync(person);
            int affected = await _hospitalSystemDBContext.SaveChangesAsync();
            if (affected == 1)
            {
                // If saved to database then return
                return person;
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

        public Task<Person?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
