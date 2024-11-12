using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class ViewShelfOfBrewingRoomModel : PageModel
    {
        private readonly IShelfRepository _repository;

        public ViewShelfOfBrewingRoomModel(IShelfRepository repository)
        {
            _repository = repository;
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
            shelfList = await _repository.GetShelfsOfBrewingRoomByRoomId(brewingRoomId);
            return Page();
        }

    }
}
