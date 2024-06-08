using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_Domain.Models;
using Labs2024_WebPages.ServicesClient;

namespace Labs2024_WebPages.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }

        public IList<Labs2024_Domain.Models.User> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userService.GetAllUsersAsync();
        }
    }
}
