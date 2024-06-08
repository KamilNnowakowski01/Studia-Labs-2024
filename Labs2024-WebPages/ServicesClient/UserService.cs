using System.Collections.Generic;
using System.Threading.Tasks;
using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;

namespace Labs2024_WebPages.ServicesClient
{
    public class UserService
    {
        private readonly ApiService _apiService;

        public UserService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _apiService.GetAsync<List<User>>("users");
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            return await _apiService.GetAsync<UserDTO>($"users/{id}");
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var createdUser = await _apiService.PostAsync<User>("users", user);
            return createdUser != null;
        }

        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            var updatedUser = await _apiService.PutAsync<UserDTO>($"users/{user.ID}", user);
            return updatedUser != null;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _apiService.DeleteAsync($"users/{id}");
            return true;
        }
    }
}
