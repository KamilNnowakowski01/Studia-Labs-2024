using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.DTO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labs2024_Domain.Enum;

namespace Labs2024_WebPages.Pages.Admin.User
{
    public class CreateModel : PageModel
    {
        private readonly UserService _userService;

        public CreateModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Labs2024_Domain.Models.User Input { get; set; }

        public List<SelectListItem> RoleOptions { get; set; }

        public void OnGet()
        {
            RoleOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = RoleEnum.Admin.ToString(), Text = RoleEnum.Admin.ToString() },
                new SelectListItem { Value = RoleEnum.User.ToString(), Text = RoleEnum.User.ToString() },
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userService.CreateUserAsync(Input);
            return RedirectToPage("./Index");
        }
    }
}
