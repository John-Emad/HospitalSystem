using AutoMapper;
using HospitalSystem.Application.DTOs;
using HospitalSystem.Application.DTOs.PatientDTOs;
using HospitalSystem.Domain.Entities.People;

namespace HospitalSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Person - Person
            CreateMap<PersonRegisterDTO, Person>(); // AddPersonHandler 
            #endregion

            #region Patient - Person
            CreateMap<PatientRegisterDTO, PersonRegisterDTO>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password)); // PatientController(SignUpAsync)
            #endregion

            #region Patient - Patient
            CreateMap<PatientRegisterDTO, AddPatientDTO>(); //PatientController(SignUpAsync)
            CreateMap<AddPatientDTO, Patient>(); // AddPatientHandler
            #endregion

        }
    }
}
