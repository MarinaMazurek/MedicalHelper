using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.Core.Abstractions
{
    public interface IUserService
    {
        Task AddAsync(UserDto userDto);

        Task<bool> IsEmailExistAsync(string email);

        Task<UserDto> GetUserByEmailAndPasswordAsync(string email, string password);

        Task<UserDto> GetUserByIdAsync(Guid id);

        Task<List<UserDto>> GetAllUsersAsync();

        Task<User?> GetCurrentUserAsync();

        ClaimsPrincipal GetPrincipal(UserDto userDto);        
    }
}
