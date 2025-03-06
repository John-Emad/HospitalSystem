using HospitalSystem.Domain.Entities.People;
using MediatR;

namespace HospitalSystem.Application.Features.PatientFeatures.Queries
{
    public record class GetAllPatientsQuery : IRequest<List<Patient>>;
}
