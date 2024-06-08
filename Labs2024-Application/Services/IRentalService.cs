using Labs2024_Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_Application.Services
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> GetAllRentalsAsync();
        Task<RentalDTO> GetRentalByIdAsync(int id);
        Task AddRentalAsync(RentalDTO rentalDto);
        Task UpdateRentalAsync(RentalDTO rentalDto);
        Task DeleteRentalAsync(int id);
        Task<string> RentCarAsync(int userId, int carId);
        Task<string> ReturnCarAsync(int userId, int carId);
        Task<IEnumerable<CarDTO>> GetRentedCarsAsync();
    }
}
