using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using System.Threading.Tasks;

namespace Labs2024_WebPages.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly AuthenticationService _authService;

        public LoginModel(AuthenticationService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class LoginInputModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _authService.LoginAsync(Input.Username, Input.Password);
            if (result)
            {
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Invalid login attempt. Please check your username and password.";
            ModelState.AddModelError(string.Empty, ErrorMessage);
            return Page();
        }
    }
}
