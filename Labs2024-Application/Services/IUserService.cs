using Labs2024_Domain.DTO;
using Labs2024_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs2024_Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<User> GetUserByLoginAsync(string login);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(int id);
        Task RegisterUserAsync(RegisterDTO registerDTO);
    }
}
