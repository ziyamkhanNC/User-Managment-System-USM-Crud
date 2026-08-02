using USMFrontend.Models;

namespace USMFrontend.Services;

public interface IUserApiService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();

    Task<UserDto?> GetUserByIdAsync(int id);

    Task<UserDto> CreateUserAsync(CreateUserDto dto);

    Task UpdateUserAsync(int id, UpdateUserDto dto);

    Task DeleteUserAsync(int id);
}