using api.Dtos.Account;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<NewUserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

            if (user == null || !PINHasher.VerifyPIN(loginDto.PIN, user.PIN))
                throw new UnauthorizedAccessException("Invalid credentials.");

            return new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<NewUserDto> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _userManager.Users.FirstOrDefaultAsync(u =>
                                                u.Email == registerDto.Email ||
                                                u.UserName == registerDto.UserName ||
                                                u.PIN == registerDto.PIN);

            if (existingUser != null)
                throw new ApplicationException("User with this email, username or PIN already exists!");

            var hashedPIN = PINHasher.HashPIN(registerDto.PIN);

            var appUser = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                Email = registerDto.Email.ToLower(),
                PhoneNumber = registerDto.PhoneNumber,
                PIN = hashedPIN,
                Role = UserRole.Manager
            };

            var result = await _userManager.CreateAsync(appUser);
            if (!result.Succeeded)
                throw new ApplicationException("Error creating user");

            await _userManager.AddToRoleAsync(appUser, "Manager");

            return new NewUserDto
            {
                UserName = appUser.UserName,
                Email = appUser.Email,
                Token = _tokenService.CreateToken(appUser)
            };
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString()
            });
        }
    }
}
