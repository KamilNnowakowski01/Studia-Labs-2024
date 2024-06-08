using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_Domain.DTO;
using Labs2024_WebPages.ServicesClient;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Labs2024_WebPages.Pages.Admin.Car
{
    public class CreateModel : PageModel
    {
        private readonly ICarService _carService;

        public CreateModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarDTO Input { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _carService.CreateCarAsync(Input);
            return RedirectToPage("./Index");
        }
    }
}
