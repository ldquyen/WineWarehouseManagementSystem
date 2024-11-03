using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class ViewBrewingRoomModel : PageModel
    {
        private readonly IBrewingRoomRepository _room;

        public ViewBrewingRoomModel(IBrewingRoomRepository room)
        {
            _room = room;
        }
        public List<BrewingRoom> BrewingRoomList { get; set; } = new List<BrewingRoom>();
        public async Task OnGet(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                BrewingRoomList = await _room.GetAllRoomAsync();
            }
            else
            {
                await OnGetSearchByName(name);
            }
        }

        public async Task<IActionResult> OnGetSearchByName(string name)
        {
            BrewingRoomList = await _room.GetBrewingByRoomNameAsync(name);
            return Page();
        }
    }
}
