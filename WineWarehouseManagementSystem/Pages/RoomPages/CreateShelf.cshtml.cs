using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Interface;
using Repositories.Repository;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class CreateShelfModel : PageModel
    {
        private readonly IBrewingRoomRepository _room;
        private readonly IShelfRepository _shelf;
        public CreateShelfModel(IBrewingRoomRepository room, IShelfRepository shelf)
        {
            _shelf = shelf;
            _room = room;
        }

        [BindProperty]
        public Shelf Shelf { get; set; }
        [BindProperty]
        public BrewingRoom BrewingRoom { get; set; }
        public SelectList BrewingRoomList { get; set; }
        public async Task<IActionResult> OnGet()
        {
             await LoadData();
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            var existShelf = await _shelf.GetShelfByShelfName(Shelf.ShelfName);
            if (existShelf != null)
            {
                await LoadData();
                TempData["Message"] = "Duplicate Shelf Name";
                return Page();
            }
            if(Shelf.MaxQuantity <= 0)
            {
                 await LoadData();
                TempData["Message"] = "Max quantity is invalid";
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Shelf = new Shelf
                {
                    ShelfName = Shelf.ShelfName,
                    BrewingRoomId = BrewingRoom.BrewingRoomId,
                    UseQuantity = Shelf.UseQuantity,
                    MaxQuantity = Shelf.MaxQuantity,
                };
                await LoadData();
                return Page();
            }
            Shelf.UseQuantity = 0;
            Shelf.BrewingRoomId = BrewingRoom.BrewingRoomId;
            await _shelf.AddShelf(Shelf);
            int newShelfId = Shelf.ShelfId;
            return RedirectToPage("/RoomPages/ViewShelf");
        }

        private async Task LoadData()
        {
            var brewingRooms = await _room.GetAllRoomAsync();
            BrewingRoomList = new SelectList(brewingRooms, "BrewingRoomId", "RoomName");
        }
    }
}
