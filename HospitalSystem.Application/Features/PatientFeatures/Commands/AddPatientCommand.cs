using MediatR;
using HospitalSystem.Domain.Entities.People;
using HospitalSystem.Application.DTOs.PatientDTOs;

namespace HospitalSystem.Application.Features.PatientFeatures.Commands
{
    public record class AddPatientCommand(AddPatientDTO addPatientDTO) : IRequest<Patient>;
}
