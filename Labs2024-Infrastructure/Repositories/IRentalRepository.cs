using Labs2024_Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_Infrastructure.Repositories
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
        Task<Rental> GetActiveRentalForCarAsync(int carId);
        Task<Rental> GetActiveRentalForUserAsync(int userId);
    }
}
