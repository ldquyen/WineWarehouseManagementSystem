using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        public async Task AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllsCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetCategoryByName(string name)
        {
            return await _context.Categories.Where(x => x.CategoryName.Contains(name)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> CheckCategoryName(string categoryName)
        {
            return await _context.Categories.AnyAsync(x => x.CategoryName == categoryName);
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
        }

        public async Task UpdateCategory(Category category)
        {
            var cate = await _context.Categories.FindAsync(category.CategoryId);
            if(cate != null)
            {
                cate.CategoryName = category.CategoryName;
               // _context.Update(cate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
