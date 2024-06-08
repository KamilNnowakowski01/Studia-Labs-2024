using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Labs2024_Domain.DTO;
using Labs2024_WebPages.ServicesClient;
using Newtonsoft.Json;

namespace Labs2024_WebPages.ServicesClient
{
    public class RentalService : IRentalService
    {
        private readonly ApiService _apiService;

        public RentalService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<RentalDTO>> GetAllRentalsAsync()
        {
            return await _apiService.GetAsync<IEnumerable<RentalDTO>>("rentals");
        }

        public async Task<RentalDTO> GetRentalByIdAsync(int id)
        {
            return await _apiService.GetAsync<RentalDTO>($"rentals/{id}");
        }

        public async Task CreateRentalAsync(RentalDTO rental)
        {
            await _apiService.PostAsync<RentalDTO>("rentals", rental);
        }

        public async Task UpdateRentalAsync(RentalDTO rental)
        {
            await _apiService.PutAsync<RentalDTO>($"rentals/{rental.ID}", rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _apiService.DeleteAsync($"rentals/{id}");
        }

        public async Task<IEnumerable<RentalDTO>> GetRentedCarsAsync()
        {
            return await _apiService.GetAsync<IEnumerable<RentalDTO>>("rentals/rent");
        }

        public async Task<string> RentCarAsync(int userId, int carId)
        {
            var response = await _apiService.PostAsync<string>("rentals/rent", new { UserId = userId, CarId = carId });
            return response;
        }
    }
}
