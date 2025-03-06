using HospitalSystem.Domain.Entities.People;
using MediatR;

namespace HospitalSystem.Application.Features.PatientFeatures.Commands
{
    public record class UpdatePatientCommand(Patient patient) : IRequest<Patient>;
}
