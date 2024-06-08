using Labs2024_Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_Application.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
        Task<CarDTO> GetCarByIdAsync(int id);
        Task AddCarAsync(CarDTO carDto);
        Task UpdateCarAsync(CarDTO carDto);
        Task DeleteCarAsync(int id);
    }
}
