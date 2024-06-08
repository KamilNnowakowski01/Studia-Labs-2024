using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labs2024_Domain.Models;

namespace Labs2024_WebPages.Pages.Admin.Rental
{
    public class EditModel : PageModel
    {
        private readonly IRentalService _rentalService;

        public EditModel(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [BindProperty]
        public RentalDTO Rental { get; set; }

        public List<SelectListItem> RentalStateOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Rental = await _rentalService.GetRentalByIdAsync(id);

            if (Rental == null)
            {
                return NotFound();
            }

            RentalStateOptions = GetRentalStateOptions();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RentalStateOptions = GetRentalStateOptions();
                return Page();
            }

            await _rentalService.UpdateRentalAsync(Rental);
            return RedirectToPage("./Index");
        }

        private List<SelectListItem> GetRentalStateOptions()
        {
            var options = new List<SelectListItem>();
            foreach (var state in (RentalState[])Enum.GetValues(typeof(RentalState)))
            {
                options.Add(new SelectListItem
                {
                    Value = state.ToString(),
                    Text = state.GetDisplayName()
                });
            }
            return options;
        }
    }
}
