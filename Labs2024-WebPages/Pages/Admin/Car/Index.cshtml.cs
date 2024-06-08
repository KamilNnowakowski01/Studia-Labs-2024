using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs2024_Domain.DTO;
using Labs2024_WebPages.ServicesClient;

namespace Labs2024_WebPages.Pages.Admin.Car
{
    public class IndexModel : PageModel
    {
        private readonly ICarService _carService;

        public IndexModel(ICarService carService)
        {
            _carService = carService;
        }

        public IList<CarDTO> Cars { get; set; }

        public async Task OnGetAsync()
        {
            Cars = (IList<CarDTO>)await _carService.GetAllCarsAsync();
        }
    }
}
