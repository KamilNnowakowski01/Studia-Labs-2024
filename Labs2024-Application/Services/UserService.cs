using AutoMapper;
using Labs2024_Domain.Models;
using Labs2024_Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCrypt.Net;
using Labs2024_Domain.DTO;
using AutoMapper;

namespace Labs2024_Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _userRepository.GetUserByLoginAsync(login);
        }

        public async Task AddUserAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userDto.ID);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Copy only editable fields, leave the password unchanged
            existingUser.Login = userDto.Login;
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.PhoneNumber = userDto.PhoneNumber;
            existingUser.Role = userDto.Role;

            await _userRepository.UpdateUserAsync(existingUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task RegisterUserAsync(RegisterDTO registerDTO)
        {
            var user = new User
            {
                Login = registerDTO.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                Role = "User"
            };

            await _userRepository.AddUserAsync(user);
        }
    }
}
