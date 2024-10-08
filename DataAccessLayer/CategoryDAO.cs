﻿using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO :SingletonBase<CategoryDAO>
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
            return await _context.Categories.Where(x => x.CategoryName.Contains(name)).ToListAsync();
        }
    }
}
