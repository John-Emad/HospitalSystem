using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using MediatR;

namespace HospitalSystem.Application.Features.PersonFeatures
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
    {
        #region Fields
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region Methods
        public async Task<Person?> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            Person? updatedPerson = await _personRepository.UpdatePersonAsync(request.person);
            if (updatedPerson == null)
            {
                return null;
            }
            return updatedPerson;
        }
        #endregion
    }
}
