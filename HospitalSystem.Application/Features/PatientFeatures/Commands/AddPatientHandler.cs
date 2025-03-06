using AutoMapper;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using MediatR;

namespace HospitalSystem.Application.Features.PatientFeatures.Commands
{
    public class AddPatientHandler : IRequestHandler<AddPatientCommand, Patient>
    {

        #region Fields
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AddPatientHandler(
            IPatientRepository patientRepository, 
            IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<Patient?> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            Patient? addedPatient = await _patientRepository.AddPatientAsync(_mapper.Map<Patient>(request.addPatientDTO)); // Mapper 3.2
            if (addedPatient == null)
            {
                return null;
            }
            return addedPatient;
        }
        #endregion
    }
}
