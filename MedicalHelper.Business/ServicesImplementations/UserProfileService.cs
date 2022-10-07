using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(UserProfileDto userProfileDto)
        {
            var entity = _mapper.Map<UserProfile>(userProfileDto);
            await _unitOfWork.UserProfiles.AddAsync(entity);
        }

        public async Task<UserProfileDto> GetUserProfileByUserIdAsync(Guid userId)
        {
            var entity = await _unitOfWork.UserProfiles.GetUserProfileByUserIdAsync(userId);
            var userProfileDto = _mapper.Map<UserProfileDto>(entity);
            return userProfileDto;
        }

        public async Task<List<UserProfileDto>> GetAllUserProfilesAsync()
        {
            var entities = await _unitOfWork.UserProfiles.GetAllAsync();
            var userProfilesDto = _mapper.Map<List<UserProfileDto>>(entities);
            return userProfilesDto;
        }

    }
}
