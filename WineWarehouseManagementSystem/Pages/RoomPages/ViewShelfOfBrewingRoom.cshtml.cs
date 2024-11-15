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
        private readonly IBrewingRoomRepository _brewingRoomRepository;

        public ViewShelfOfBrewingRoomModel(IShelfRepository shelfRepository, IBrewingRoomRepository brewingRoomRepository)
        {
            _shelfRepository = shelfRepository;
            _brewingRoomRepository = brewingRoomRepository;
        }

        [BindProperty]
        public List<Shelf> shelfList { get; set; }
        public BrewingRoom BrewingRoom { get; set; }

        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int? brewingRoomId)
        {
            //exportDetails = new List<ExportDetail>();
            shelfList = await _shelfRepository.GetShelfsOfBrewingRoomByRoomId(brewingRoomId);
            BrewingRoom = await _brewingRoomRepository.GetBrewingRoomById((int)brewingRoomId);
            return Page();
        }

    }
}
