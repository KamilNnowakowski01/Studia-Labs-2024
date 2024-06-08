using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labs2024_WebPages.ServicesClient;
using Labs2024_Domain.Models;

namespace Labs2024_WebPages.Pages.User
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
