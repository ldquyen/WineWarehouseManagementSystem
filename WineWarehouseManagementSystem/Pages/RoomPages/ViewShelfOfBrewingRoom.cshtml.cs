using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class ViewShelfOfBrewingRoomModel : PageModel
    {
        private readonly IShelfRepository _shelfRepository;

        public ViewShelfOfBrewingRoomModel(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        [BindProperty]
        public List<Shelf> shelfList { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int? brewingRoomId)
        {
            //exportDetails = new List<ExportDetail>();
            shelfList = await _shelfRepository.GetShelfsOfBrewingRoomByRoomId(brewingRoomId);
            return Page();
        }

    }
}
