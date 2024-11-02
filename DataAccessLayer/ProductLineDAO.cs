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

        public async Task<bool> ReduceProductLine(int productLineId, int quantity)
        {
            var productLine = await _context.ProductLines.FirstOrDefaultAsync(pl => pl.ProductLineId == productLineId);
            int? stock = productLine.Quantity - quantity;
            if (quantity <= productLine.Quantity)
            {
                productLine.Quantity = stock;
                _context.ProductLines.Update(productLine);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
        public async Task<List<ProductLine>> GetProductLineListByProductId(int? productId)
        {
            return await _context.ProductLines.Where(pl => pl.ProductId == productId).ToListAsync();
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

