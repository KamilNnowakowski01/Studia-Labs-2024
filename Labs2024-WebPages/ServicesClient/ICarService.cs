using System.Collections.Generic;
using System.Threading.Tasks;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.ServicesClient
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
        Task<CarDTO> GetCarByIdAsync(int id);
        Task CreateCarAsync(CarDTO car);
        Task UpdateCarAsync(CarDTO car);
        Task DeleteCarAsync(int id);
    }
}
