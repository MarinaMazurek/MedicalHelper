using MedicalHelper.Core.DataTransferObjects;

namespace MedicalHelper.Core.Abstractions
{
    public interface IUserProfileService
    {
        Task AddAsync(UserProfileDto userProfileDto);

        Task<UserProfileDto> GetUserProfileByUserIdAsync(Guid userId);

        Task<List<UserProfileDto>> GetAllUserProfilesAsync();
    }
}
