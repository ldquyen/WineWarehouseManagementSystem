using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class ViewShelfModel : PageModel
    {
        private readonly IShelfRepository _shelf;

        public ViewShelfModel(IShelfRepository shelf)
        {
            _shelf = shelf;
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
