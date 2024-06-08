using Labs2024_Domain.DTO;
using Labs2024_WebPages.ServicesClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labs2024_WebPages.Pages.User.Cars
{
    public class IndexModel : PageModel
    {

        private readonly ICarService _carService;
        private readonly IRentalService _rentalService;

        public IndexModel(ICarService carService, IRentalService rentalService)
        {
            _carService = carService;
            _rentalService = rentalService;
        }

        public List<CarDTO> AvailableCars { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            var allCars = await _carService.GetAllCarsAsync();
            var rentedCars = await _rentalService.GetRentedCarsAsync();

            var rentedCarIds = new HashSet<int>(rentedCars.Select(car => car.ID));
            AvailableCars = allCars.Where(car => !rentedCarIds.Contains(car.ID)).ToList();

            return Page();

        }

        public async Task<IActionResult> OnPostRentCarAsync(int carId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int userIdInt))
            {
                return RedirectToPage("/Account/Login");
            }

            var result = await _rentalService.RentCarAsync(userIdInt, carId);
            if (result != "Car rented successfully.")
            {
                ModelState.AddModelError(string.Empty, result);
            }

            return RedirectToPage();
        }
    }
}
