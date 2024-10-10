using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ShelfDAO : SingletonBase<ShelfDAO>
    {
        public async Task AddShelf(Shelf shelf)
        {
            await _context.Shelves.AddAsync(shelf);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Shelf>> GetShelfList()
        {
            return await _context.Shelves.ToListAsync();
        }

        public async Task<bool> AddShelfQuantity(int? shelfid ,int? quantity)
        {
            var shelf = await _context.Shelves.FirstOrDefaultAsync(x => x.ShelfId == shelfid);
            int? ex = quantity + shelf.UseQuantity;
            if(ex <= shelf.MaxQuantity)
            {
                shelf.UseQuantity = ex;
                _context.Shelves.Update(shelf);
                await _context.SaveChangesAsync();
                return true;
            }else return false;
        }
    }
}
