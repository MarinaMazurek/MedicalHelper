﻿using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Models.User;
using MedicalHelper.Models.UserProfile;
using MedicalHelper.Models.Visit;

namespace MedicalHelper.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {            
            CreateMap<RegistrationViewModel,UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto,UserViewModel>();

            CreateMap<UserProfileAddViewModel, UserProfileDto>()
                 .ForMember(u => u.FullName,
                opt =>
                    opt.MapFrom(viewModel => viewModel.FirstName + " " + viewModel.LastName));

            CreateMap<Visit, VisitDto>();
            CreateMap<VisitDto, Visit>();
            CreateMap<VisitViewModel, VisitDto>();
            CreateMap<VisitDto, VisitViewModel>();

            CreateMap<UserProfileDto, UserProfile>();
            CreateMap<UserProfile, UserProfileDto>();

            CreateMap<UserProfileDto, UserProfileViewModel>();
            CreateMap<UserProfileViewModel, UserProfileDto>();
        }
    }
}
