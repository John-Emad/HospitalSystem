using HospitalSystem.Application.Interfaces;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<Person?> CreateAsync(Person person)
        {           
            return _personRepository.CreateAsync(person);
        }


        public Task<Person?> DeleteByIdAsync(string id)
        {
            return _personRepository.DeleteByIdAsync(id);
        }

        public Task<Person[]> GetAllAsync()
        {
            return _personRepository.GetAllAsync();
        }

        public Task<Person?> GetByIdAsync(string id)
        {
            return _personRepository.GetByIdAsync(id);
        }

        public Task<Person?> Update(Person person)
        {
            return _personRepository.Update(person);
        }


        Task<Person?> IPersonService.DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<Person[]> IPersonService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Person?> IPersonService.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
