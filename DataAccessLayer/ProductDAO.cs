using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO : SingletonBase<ProductDAO> 
    {
        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<List<Product>> GetListOfProduct()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<List<Product>> GetProductByName(string name)
        {
            return await _context.Products.Where(x => x.ProductName.Contains(name)).Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetProductById(int? id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> CheckProductName(string productName)
        {
            return await _context.Products.AnyAsync(x => x.ProductName == productName);
        }

        public async Task<bool> CheckCategoryInProduct(int categoryId)
        {
            return await _context.Products.AnyAsync(x => x.CategoryId == categoryId);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            else
                return false;
            
        }
    }
}
