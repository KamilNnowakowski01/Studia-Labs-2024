using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_Domain.DTO;
using Labs2024_WebPages.ServicesClient;

namespace Labs2024_WebPages.Pages.Admin.Car
{
    public class EditModel : PageModel
    {
        private readonly ICarService _carService;

        public EditModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarDTO Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = await _carService.GetCarByIdAsync(id);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _carService.UpdateCarAsync(Car);
            return RedirectToPage("./Index");
        }
    }
}
