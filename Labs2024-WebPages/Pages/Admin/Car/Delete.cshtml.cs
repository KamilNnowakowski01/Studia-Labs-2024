using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_Domain.Models;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.Pages.Admin.Car
{
    public class DeleteModel : PageModel
    {
        private readonly ICarService _carService;

        public DeleteModel(ICarService carService)
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _carService.DeleteCarAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
