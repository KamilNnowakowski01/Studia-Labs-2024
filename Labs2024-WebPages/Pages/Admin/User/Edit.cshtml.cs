using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labs2024_Domain.Enum;

namespace Labs2024_WebPages.Pages.Admin.User
{
    public class EditModel : PageModel
    {
        private readonly UserService _userService;

        public EditModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserDTO User { get; set; }

        public List<SelectListItem> RoleOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _userService.GetUserByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            RoleOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = RoleEnum.Admin.ToString(), Text = RoleEnum.Admin.ToString() },
                new SelectListItem { Value = RoleEnum.User.ToString(), Text = RoleEnum.User.ToString() }
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userService.UpdateUserAsync(User);
            return RedirectToPage("./Index");
        }
    }
}
