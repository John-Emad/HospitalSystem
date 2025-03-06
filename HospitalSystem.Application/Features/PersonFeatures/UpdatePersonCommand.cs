using HospitalSystem.Domain.Entities.People;
using MediatR;

namespace HospitalSystem.Application.Features.PersonFeatures
{
    public record UpdatePersonCommand(Person person) : IRequest<Person>;
}
