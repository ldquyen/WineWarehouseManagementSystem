using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class CreateBrewingRoomModel : PageModel
    {
        private readonly IBrewingRoomRepository _room;
        private readonly IProductRepository _productRepository;
        public CreateBrewingRoomModel(IBrewingRoomRepository room)
        {
            _room = room;
        }

        [BindProperty]
        public BrewingRoom BrewingRoom { get; set; }

        public async Task OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var existRoom = await _room.GetBrewingByRoomNameAsync(BrewingRoom.RoomName);
            if (existRoom != null)
            {
                TempData["Message"] = "Duplicate Room Name";
                return Page();
            }
            if(BrewingRoom.Temperature <= 0 || BrewingRoom.Humidity <= 0)
            {
                TempData["Message"] = "Invalid number";
                return Page();
            }

            if (!ModelState.IsValid)
            {
                BrewingRoom = new BrewingRoom
                {
                    RoomName = BrewingRoom.RoomName,
                    Temperature = BrewingRoom.Temperature,
                    Humidity = BrewingRoom.Humidity,
                    Note = BrewingRoom.Note,
                };
                return Page();
            }
            await _room.CreateBrewingRoomAsync(BrewingRoom);
            int newBrewingRoomId = BrewingRoom.BrewingRoomId;
            return RedirectToPage("/RoomPages/ViewBrewingRoom");
        }
    }
}
