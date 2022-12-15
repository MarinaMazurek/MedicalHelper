using AutoMapper;
using MedicalHelper.Core.Abstractions;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.Data.Abstractions;
using MedicalHelper.DataBase.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace MedicalHelper.Business.ServicesImplementations
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public async Task AddAsync(UserDto userDto)
        {
            var entity = _mapper.Map<User>(userDto);

            var password = CreateMd5(entity.PasswordHash);

            entity.PasswordHash = password;

            await _unitOfWork.Users.AddAsync(entity);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _unitOfWork.Users.Get()
                .AsNoTracking().AnyAsync(entity => entity.Email.Equals(email));
        }

        public async Task<UserDto> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            var passwordMd5 = CreateMd5(password); 
            var user = await _unitOfWork.Users
                .GetUserByEmailAndPasswordAsync(email, passwordMd5);
             
            if(user != null)
            {
                user.PasswordHash = password;
            }
            var userReturnDto = _mapper.Map<UserDto>(user);
            return userReturnDto;            
        }
                
        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetEntityByIdAsync(id);
            var userReturnDto = _mapper.Map<UserDto>(user);
            return userReturnDto;
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(email);
            var userReturnDto = _mapper.Map<UserDto>(user);
            return userReturnDto;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var usersReturnDto = _mapper.Map<List<UserDto>>(users);
            return usersReturnDto;
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            var idStr = _httpContextAccessor
                .HttpContext
                .User
                .Claims
                .SingleOrDefault(x => x.Type == "Id")
                ?.Value;

            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = Guid.Parse(idStr);
            return await _unitOfWork.Users.GetEntityByIdAsync(id);
        }

        public ClaimsPrincipal GetPrincipal(UserDto userDto)  
        {
            var claims = new List<Claim>
            {
                new Claim("Id", userDto.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, "MedicalHelperCoockie");

            return new ClaimsPrincipal(claimsIdentity);
        }

        public bool IsAdmin() => GetCurrentUserAsync()?.Result?.Role?.Name == "Admin";

        private string CreateMd5(string password)
        {
            var passwordSalt = _configuration["UserSecrets:PasswordSalt"];

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(password + passwordSalt);
                var hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
