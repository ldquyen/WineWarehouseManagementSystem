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
            return await _context.Shelves.AsNoTracking().ToListAsync();
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

        public async Task<bool> ReduceShelfQuantity(int? shelfId, int? quantity)
        {
            var shelf = await _context.Shelves.FirstOrDefaultAsync(x => x.ShelfId == shelfId);

            int? ex = shelf.UseQuantity - quantity;
            if (quantity <= shelf.UseQuantity)
            {
                shelf.UseQuantity = ex;
                _context.Shelves.Update(shelf);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<Shelf> GetShelfByShelfId(int? shelfId)
        {
            return await _context.Shelves.FirstOrDefaultAsync(s => s.ShelfId == shelfId);
        }
        public async Task<List<Shelf>> GetShelfsByShelfName(string shelfName)
        {
            return await _context.Shelves.Where(x => x.ShelfName.Contains(shelfName)).AsNoTracking().ToListAsync();
        }
        public async Task<Shelf> GetShelfByShelfName(string shelfName)
        {
            return await _context.Shelves.FirstOrDefaultAsync(x => x.ShelfName == shelfName);
        }
        public async Task<List<Shelf>> GetShelfsOfProductLineByProductId(int? productId)
        {
            return await _context.ProductLines.Where(pl => pl.ProductId == productId).Select(pl => pl.Shelf).AsNoTracking().ToListAsync();
        }

        public async Task<List<Shelf>> GetShelfsOfBrewingRoomByRoomId(int? brewingRoomId)
        {
            return await _context.Shelves.Where(s => s.BrewingRoomId == brewingRoomId).Include(x => x.BrewingRoom).AsNoTracking().ToListAsync();
        }

       
        public async Task UpdateShelf(Shelf shelf)
        {
            var existShelf = await _context.Shelves.FindAsync(shelf.ShelfId);
            if (existShelf != null)
            {
                existShelf.UseQuantity = shelf.UseQuantity;
                existShelf.MaxQuantity = shelf.MaxQuantity;
                
                // _context.Update(existShelf);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CheckShelfIsAnyProduct(int shelfId)
        {
            var existShelf = await _context.Shelves.FindAsync(shelfId);
            if (existShelf != null)
            {
                return existShelf.UseQuantity == 0;
            }
            else
                return false;
            
        }
    }
}
