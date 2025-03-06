using AutoMapper;
using HospitalSystem.Application.DTOs;
using HospitalSystem.Application.DTOs.PatientDTOs;
using HospitalSystem.Application.Features.PatientFeatures.Commands;
using HospitalSystem.Application.Features.PatientFeatures.Queries;
using HospitalSystem.Application.Features.PersonFeatures;
using HospitalSystem.Domain.Entities.People;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<Person> _userManager;
        #endregion

        #region Constructors
        public PatientController(IMediator mediator, IMapper mapper, UserManager<Person> userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Controllers
        [HttpPost("AddNew")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync([FromBody]PatientRegisterDTO patientFromRequest)
        {
            Person? addedPerson = await _mediator.Send(new AddPersonCommand(_mapper.Map<PersonRegisterDTO>(patientFromRequest))); // Mapper 2.1
            if (addedPerson == null)
            {
                return BadRequest("Can not Add Person");
            }
            AddPatientDTO addPatientDTO = _mapper.Map<AddPatientDTO>(patientFromRequest); // Mapper 3.1
            addPatientDTO.PersonId = addedPerson.Id;
            Patient? addedPatient = await _mediator.Send(new AddPatientCommand(addPatientDTO));
            if (addedPatient == null)
            {
                return BadRequest("Can not Add Patient");
            }

            await _mediator.Send(new AssignPatientToPersonCommand(addedPatient));

            return Ok(addedPatient);
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatientsAsync()
        {
            return Ok(await _mediator.Send(new GetAllPatientsQuery()));
        }


            #endregion
        }
}
