using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Microsoft.AspNetCore.Mvc;

namespace Labs2024_WebPages.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly JwtService _jwtService;

        public LogoutModel(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public IActionResult OnGet()
        {
            _jwtService.RemoveToken();
            return RedirectToPage("/Index");
        }
    }
}
