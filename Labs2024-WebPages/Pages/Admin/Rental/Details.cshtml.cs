using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.Pages.Admin.Rental
{
    public class DetailsModel : PageModel
    {
        private readonly IRentalService _rentalService;

        public DetailsModel(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public RentalDTO Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Rental = await _rentalService.GetRentalByIdAsync(id);

            if (Rental == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
