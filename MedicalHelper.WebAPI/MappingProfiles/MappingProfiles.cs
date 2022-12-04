using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.WebAPI.Models;
using MedicalHelper.WebAPI.Models.Requests;

namespace MedicalHelper.WebAPI.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {            
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
                                   
            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();

            CreateMap<VisitModel, VisitDto>();
            CreateMap<VisitDto, VisitModel>();

            CreateMap<Vaccination, VaccinationDto>();
            CreateMap<VaccinationDto, Vaccination>();
            
            CreateMap<Medicine, MedicineDto>();
            CreateMap<MedicineDto, Medicine>();
           
            CreateMap<UserProfileDto, UserProfile>();
            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<RegisterUserRequestModel, UserDto>()
                .ForMember(dto => dto.PasswordHash,opt => opt.MapFrom(entity => entity.Password));
        }
    }
}
