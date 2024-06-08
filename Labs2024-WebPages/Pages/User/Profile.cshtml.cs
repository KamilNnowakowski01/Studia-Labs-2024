using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;
using System.Threading.Tasks;

namespace Labs2024_WebPages.Pages.User
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _userService;

        public ProfileModel(UserService userService)
        {
            _userService = userService;
        }

        public UserDTO UserDto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Assuming the user's ID is obtained from the authenticated user's claims
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int id))
            {
                return RedirectToPage("/Account/Login");
            }

            UserDto = await _userService.GetUserByIdAsync(id);

            if (UserDto == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
