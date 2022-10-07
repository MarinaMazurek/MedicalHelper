using MedicalHelper.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.Abstractions
{
    public interface IUserProfileService
    {
        Task AddAsync(UserProfileDto userProfileDto);

        Task<UserProfileDto> GetUserProfileByUserIdAsync(Guid userId);

        Task<List<UserProfileDto>> GetAllUserProfilesAsync();
    }
}
