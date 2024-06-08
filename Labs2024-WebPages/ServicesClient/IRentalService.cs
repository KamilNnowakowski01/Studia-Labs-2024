using System.Collections.Generic;
using System.Threading.Tasks;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.ServicesClient
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTO>> GetAllRentalsAsync();
        Task<RentalDTO> GetRentalByIdAsync(int id);
        Task CreateRentalAsync(RentalDTO rental);
        Task UpdateRentalAsync(RentalDTO rental);
        Task DeleteRentalAsync(int id);
        Task<IEnumerable<RentalDTO>> GetRentedCarsAsync();
        Task<string> RentCarAsync(int userId, int carId);
    }
}
