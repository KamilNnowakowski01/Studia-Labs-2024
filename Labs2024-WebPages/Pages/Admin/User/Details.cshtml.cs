using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_Domain.Models;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;

namespace Labs2024_WebPages.Pages.Admin.User
{
    public class DetailsModel : PageModel
    {
        private readonly UserService _userService;

        public DetailsModel(UserService userService)
        {
            _userService = userService;
        }

        public UserDTO User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _userService.GetUserByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
