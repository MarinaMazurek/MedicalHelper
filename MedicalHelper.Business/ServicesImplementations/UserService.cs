using AutoMapper;
using MedicalHelper.Core.DataTransferObjects;
using MedicalHelper.DataBase.Entities;
using MedicalHelper.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MedicalHelper.Business.ServicesImplementations
{

    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserRepository userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddAsync(UserDto userDto)
        {
            var entity = _mapper.Map<User>(userDto);
            await _userRepository.AddAsync(entity);
        }

        public async Task<UserDto> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            var user = await _userRepository.GetUserByLoginAndPasswordAsync(login, password);
            var userReturnDto = _mapper.Map<UserDto>(user);
            return userReturnDto;
        }

        //для администратора
        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userReturnDto = _mapper.Map<UserDto>(user);
            return userReturnDto;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
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
            return await _userRepository.GetUserByIdAsync(id);
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
    }
}
