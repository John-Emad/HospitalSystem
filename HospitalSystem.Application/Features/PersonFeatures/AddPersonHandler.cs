using AutoMapper;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using MediatR;

namespace HospitalSystem.Application.Features.PersonFeatures
{
    public class AddPersonHandler : IRequestHandler<AddPersonCommand, Person>
    {
        #region Fields
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AddPersonHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public  async Task<Person?> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            Person? addedPerson = await _personRepository.AddPersonAsync(_mapper.Map<Person>(request.personRegisterDTO)); // Mapper 1.1
            if (addedPerson == null) 
            { 
                return null;
            }
            return addedPerson;
        }
        #endregion
    }
}
