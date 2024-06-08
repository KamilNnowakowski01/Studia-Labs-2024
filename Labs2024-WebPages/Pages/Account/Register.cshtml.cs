using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using System.Threading.Tasks;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AuthenticationService _authService;

        public RegisterModel(AuthenticationService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public RegisterDTO Input { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _authService.RegisterAsync(Input);
            if (result)
            {
                return RedirectToPage("./Login");
            }

            ErrorMessage = "Registration failed. Please check your details and try again.";
            ModelState.AddModelError(string.Empty, ErrorMessage);
            return Page();
        }
    }
}
