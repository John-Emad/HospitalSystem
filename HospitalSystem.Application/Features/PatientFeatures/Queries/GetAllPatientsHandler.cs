using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Features.PatientFeatures.Queries
{
    class GetAllPatientsHandler : IRequestHandler<GetAllPatientsQuery, List<Patient>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<Patient>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            return await _patientRepository.GetAllPatientsAsync();
        }
    }
}
