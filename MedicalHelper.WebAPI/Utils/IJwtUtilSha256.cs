using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.WebAPI.Models.Responses;

namespace MedicalHelper.WebAPI.Utils
{
    public interface IJwtUtilSha256
    {
        Task<TokenResponse> GenerateTokenAsync(UserDto dto);
    }
}
