using HospitalSystem.Application.DTOs;
using HospitalSystem.Domain.Entities.People;
using MediatR;

namespace HospitalSystem.Application.Features.PersonFeatures
{
    public record AddPersonCommand(PersonRegisterDTO personRegisterDTO) : IRequest<Person>;
}
