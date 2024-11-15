using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using Repositories.Interface;
using System;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class ViewShelfModel : PageModel
    {
        private readonly IShelfRepository _shelf;
        private readonly IBrewingRoomRepository _brewingRoom;

        public ViewShelfModel(IShelfRepository shelf, IBrewingRoomRepository brewingRoom)
        {
            _shelf = shelf;
            _brewingRoom = brewingRoom;
        }

        public List<Shelf> ShelfList { get; set; } = new List<Shelf>();
        public async Task OnGet(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ShelfList = await _shelf.GetAllShelf();
            }
            else
            {
                await OnGetSearchByName(name);
            }
        }

        public async Task<IActionResult> OnGetSearchByName(string name)
        {
            ShelfList = await _shelf.GetShelfsByShelfName(name);
            return Page();
        }

    }
}
