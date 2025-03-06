using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using MediatR;

namespace HospitalSystem.Application.Features.PatientFeatures.Commands
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Patient>
    {
        #region Fields
        private readonly IPatientRepository _patientRepository;
        #endregion

        #region Constructors
        public UpdatePatientHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        #endregion


        #region Methods
        public Task<Patient?> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            return _patientRepository.UpdatePatientAsync(request.patient);
        }
        #endregion
    }
}
