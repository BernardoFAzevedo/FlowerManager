using api.Dtos.Account;
using api.Models;

namespace api.Interfaces
{
    public interface IUserService
    {
        Task<NewUserDto> LoginAsync(LoginDto loginDto);
        Task<NewUserDto> RegisterAsync(RegisterDto registerDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
