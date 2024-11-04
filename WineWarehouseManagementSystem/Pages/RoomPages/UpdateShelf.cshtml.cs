using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Interface;

namespace WineWarehouseManagementSystem.Pages.RoomPages
{
    public class UpdateShelfModel : PageModel
    {
        private readonly IShelfRepository _repository;

        public UpdateShelfModel(IShelfRepository repository)
        {
            _repository = repository;
        }
        [BindProperty]
        public Shelf shelf { get; set; }
        public async Task OnGet(int? id)
        {
            await LoadData(id);
        }

        private async Task<IActionResult> LoadData(int? id)
        {
            shelf = await _repository.GetShelfByShelfId(id);
            if (shelf == null)
            {
                TempData["Message"] = "Shelf not found.";
                return Page();
            }

            return Page();
        }

        public async Task OnPost()
        {
            if(shelf.MaxQuantity <= 0 || shelf.MaxQuantity < shelf.UseQuantity)
            {
                TempData["Message"] = "Update Shelf fail because quantity is invalid";
                await LoadData(shelf.ShelfId);
            }
            else
            {
                await _repository.UpdateShelf(shelf);
                TempData["Message"] = "Update Shelf Successful";
                await LoadData(shelf.ShelfId);
            }
        }
    }
}
