using HospitalSystem.Application.Interfaces;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;

namespace HospitalSystem.Application
{
    public class PersonService : IPersonService
    {
        #region Fields
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region Methods
        public async Task<Person?> AddPersonAsync(Person person)
        {
            Person? AddedPerson = await _personRepository.AddPersonAsync(person);
            if (AddedPerson is null)
            {
                return null;
            }
            return AddedPerson;
        }

        public Task<Person?> UpdatePersonAsync(Person person)
        {
            return _personRepository.UpdatePersonAsync(person);
        }

        public Task<Person?> AssignPatientId(string personId, int patientId)
        {
            return _personRepository.AssignPatientId(personId, patientId);
        }

        public Task<Person?> DeleteByIdAsync(string id)
        {
            return _personRepository.DeleteByIdAsync(id);
        }

        public Task<Person?> GetByIdAsync(string id)
        {
            return _personRepository.GetByIdAsync(id);
        }
        public Task<Person[]> GetAllPeopleAsync()
        {
            throw new NotImplementedException();
        }


        #endregion



    }
}
