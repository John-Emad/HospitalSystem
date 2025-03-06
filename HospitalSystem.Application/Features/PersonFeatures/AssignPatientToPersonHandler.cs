using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using MediatR;

namespace HospitalSystem.Application.Features.PersonFeatures
{
    public class AssignPatientToPersonHandler : IRequestHandler<AssignPatientToPersonCommand, Person>
    {
        #region Fields
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructors
        public AssignPatientToPersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region Methods
        Task<Person?> IRequestHandler<AssignPatientToPersonCommand, Person>.Handle(AssignPatientToPersonCommand request, CancellationToken cancellationToken)
        {
            return _personRepository.AssignPatientId(request.patient.PersonId, request.patient.PatientId);
        }
        #endregion
    }
}
