using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using System.Security.Claims;

namespace MedicalHelper.Core.Abstractions
{
    public interface IUserService
    {
        Task AddAsync(UserDto userDto);

        Task<bool> IsEmailExistAsync(string email);

        Task<UserDto> GetUserByEmailAndPasswordAsync(string email, string password);

        Task<UserDto> GetUserByIdAsync(Guid id);

        Task<UserDto> GetUserByEmailAsync(string email);

        Task<List<UserDto>> GetAllUsersAsync();

        Task<User?> GetCurrentUserAsync();

        ClaimsPrincipal GetPrincipal(UserDto userDto);

        bool IsAdmin();
    }
}
