using HospitalSystem.Domain.Entities.People;
using MediatR;

namespace HospitalSystem.Application.Features.PersonFeatures
{
    public record class AssignPatientToPersonCommand(Patient patient) : IRequest<Person>;
}
