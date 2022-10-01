using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;

namespace MedicalHelper.Business.ServicesImplementations
{
    public class UserProfileService
    {
        private readonly UserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileService(UserProfileRepository userProfileRepository, IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(UserProfileDto userProfileDto)
        {
            var entity = _mapper.Map<UserProfile>(userProfileDto);
            await _userProfileRepository.AddAsync(entity);
        }

        public async Task<UserProfileDto> GetUserProfileByUserIdAsync(Guid userId)
        {
            var entity = await _userProfileRepository.GetUserProfileByUserIdAsync(userId);
            var userProfileDto = _mapper.Map<UserProfileDto>(entity);
            return userProfileDto;
        }

        public async Task<List<UserProfileDto>> GetAllUserProfilesAsync()
        {
            var entities = await _userProfileRepository.GetAllAsync();
            var userProfilesDto = _mapper.Map<List<UserProfileDto>>(entities);
            return userProfilesDto;
        }

    }
}
