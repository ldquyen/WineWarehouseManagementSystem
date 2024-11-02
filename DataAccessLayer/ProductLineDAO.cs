using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductLineDAO : SingletonBase<ProductLineDAO>
    {
        public async Task CreateProductLine(ProductLine productLine)
        {
            await _context.AddAsync(productLine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ReduceProductLine(int productLineId, int? quantity)
        {
            if (quantity == null || quantity <= 0)
            {
                // Invalid quantity
                return false;
            }

            var productLine = await _context.ProductLines.FirstOrDefaultAsync(pl => pl.ProductLineId == productLineId);

            if (productLine == null)
            {
                // Product line not found
                return false;
            }

            if (quantity <= productLine.Quantity)
            {
                productLine.Quantity = productLine.Quantity - quantity;
                _context.ProductLines.Update(productLine);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                // Not enough stock
                return false;
            }
        }
        public async Task<ProductLine> GetProductIdByInfor(int? productId, int? year, int? shelfId)
        {
            return await _context.ProductLines.FirstOrDefaultAsync(pl => pl.ProductId == productId && pl.ProductYear == year && pl.ShelfId == shelfId);
        }
        public async Task<ProductLine> GetProductLineByProductLineId(int? productLineId)
        {
            return await _context.ProductLines.FirstOrDefaultAsync(pl => pl.ProductLineId == productLineId);
        }
        public async Task<List<ProductLine>> GetProductLineListByProductId(int? productId)
        {
            return await _context.ProductLines.Where(pl => pl.ProductId == productId).ToListAsync();
        }
        public async Task<List<ProductLine>> GetProductLineListByProductId(int productId)
        {
            return await _context.ProductLines.Where(pl => pl.ProductId == productId).Include(x => x.Shelf).ToListAsync();
        }

        public async Task<List<int?>> GetListManufacturingYearOfProduct(int? productId)
        {
            return await _context.ProductLines.Where(pl => pl.ProductId == productId).Select(pl => pl.ProductYear).ToListAsync();
        }

    }
}

