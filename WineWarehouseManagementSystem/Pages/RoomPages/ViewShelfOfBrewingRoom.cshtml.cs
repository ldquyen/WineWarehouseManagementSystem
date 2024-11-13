using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class ViewShelfOfBrewingRoomModel : PageModel
    {
        private readonly IShelfRepository _repository;
        private readonly IBrewingRoomRepository _brewingRoomRepository;

        public ViewShelfOfBrewingRoomModel(IShelfRepository repository, IBrewingRoomRepository brewingRoomRepository)
        {
            _repository = repository;
            _brewingRoomRepository = brewingRoomRepository;
        private readonly IShelfRepository _shelfRepository;

        public ViewShelfOfBrewingRoomModel(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
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
            shelfList = await _repository.GetShelfsOfBrewingRoomByRoomId(brewingRoomId);
            BrewingRoom = await _brewingRoomRepository.GetBrewingRoomById((int)brewingRoomId);
            shelfList = await _shelfRepository.GetShelfsOfBrewingRoomByRoomId(brewingRoomId);
            return Page();
        }

    }
}
