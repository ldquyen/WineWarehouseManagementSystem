using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

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
            //BrewingRoom = new BrewingRoom
            //{
            //    RoomName = BrewingRoom.RoomName,
            //    Temperature = BrewingRoom.Temperature,
            //    Humidity = BrewingRoom.Humidity,
            //    Note = BrewingRoom.Note,
            //};

        }

        public async Task<IActionResult> OnPost()
        {
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
            //return RedirectToPage("/RoomPages/CreateBrewingRoom", new
            //{
            //    BrewingRoomId = newBrewingRoomId,
            //});
            return RedirectToPage("/RoomPages/ViewBrewingRoom");
        }
    }
}
