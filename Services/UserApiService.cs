using System.Net.Http.Json;
using USMFrontend.Models;

namespace USMFrontend.Services;

public class UserApiService : IUserApiService
{
    private readonly HttpClient _httpClient;

    public UserApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<UserDto>>("api/users")
               ?? new List<UserDto>();
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<UserDto>($"api/users/{id}");
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/users", dto);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserDto>()
               ?? throw new Exception("Failed to create user.");
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/users/{id}", dto);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteUserAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/users/{id}");

        response.EnsureSuccessStatusCode();
    }
}