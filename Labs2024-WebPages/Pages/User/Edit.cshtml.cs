using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;
using System.Threading.Tasks;

namespace Labs2024_WebPages.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;

        public EditModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserDTO Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Assuming the user's ID is obtained from the authenticated user's claims
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int id))
            {
                return RedirectToPage("/Account/Login");
            }

            Input = await _userService.GetUserByIdAsync(id);

            if (Input == null)
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

            // Pobierz bie¿¹ce dane u¿ytkownika, aby zachowaæ rolê
            var existingUser = await _userService.GetUserByIdAsync(Input.ID);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Zachowaj rolê u¿ytkownika
            Input.Role = existingUser.Role;

            await _userService.UpdateUserAsync(Input);
            return RedirectToPage("/User/Profile");
        }
    }
}
