using System.Collections.Generic;
using System.Threading.Tasks;
using Labs2024_Domain.DTO;
using Labs2024_WebPages.ServicesClient;

namespace Labs2024_WebPages.ServicesClient
{
    public class CarService : ICarService
    {
        private readonly ApiService _apiService;

        public CarService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync()
        {
            return await _apiService.GetAsync<IEnumerable<CarDTO>>("cars");
        }

        public async Task<CarDTO> GetCarByIdAsync(int id)
        {
            return await _apiService.GetAsync<CarDTO>($"cars/{id}");
        }

        public async Task CreateCarAsync(CarDTO car)
        {
            await _apiService.PostAsync<CarDTO>("cars", car);
        }

        public async Task UpdateCarAsync(CarDTO car)
        {
            await _apiService.PutAsync<CarDTO>($"cars/{car.ID}", car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _apiService.DeleteAsync($"cars/{id}");
        }
    }
}
