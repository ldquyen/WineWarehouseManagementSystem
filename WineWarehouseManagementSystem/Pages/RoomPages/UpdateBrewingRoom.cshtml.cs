using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class UpdateBrewingRoomModel : PageModel
    {
        private readonly IBrewingRoomRepository _roomRepository;

        public UpdateBrewingRoomModel(IBrewingRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [BindProperty]
        public BrewingRoom BrewingRoom { get; set; }
        public async Task OnGet(int id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int id)
        {
            BrewingRoom = await _roomRepository.GetBrewingRoomById(id);
            if (BrewingRoom == null)
            {
                TempData["Message"] = "Brewing Room not found.";
                return Page();
            }

            return Page();
        }

        public async Task OnPost()
        {
            if (BrewingRoom.Temperature <= 0 || BrewingRoom.Humidity <= 0)
            {
                TempData["Message"] = "Invalid number";
                await LoadData(BrewingRoom.BrewingRoomId);
            }
            await _roomRepository.UpdateBrewingRoomAsync(BrewingRoom);
            TempData["Message"] = "Update Brewing Room Successful";
            await LoadData(BrewingRoom.BrewingRoomId);
        }
    }
}
