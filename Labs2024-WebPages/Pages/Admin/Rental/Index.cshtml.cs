using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.Pages.Admin.Rental
{
    public class IndexModel : PageModel
    {
        private readonly IRentalService _rentalService;

        public IndexModel(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IList<RentalDTO> Rentals { get; set; }

        public async Task OnGetAsync()
        {
            Rentals = (IList<RentalDTO>)await _rentalService.GetAllRentalsAsync();
        }
    }
}
