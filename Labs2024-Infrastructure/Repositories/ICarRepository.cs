using Labs2024_Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labs2024_Infrastructure.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
    }
}
