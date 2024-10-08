﻿using BusinessObject.Models;
using DataAccessLayer;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;

        public CategoryRepository()
        {
            _categoryDAO = CategoryDAO.instance;
        }

        public async Task CreateCategory(Category category)
        {
            await _categoryDAO.AddCategory(category);
        }
        public async Task<List<Category>> GetAlls()
        {
            return await _categoryDAO.GetAllsCategory();
        }

        public async Task<List<Category>> GetCategoryByName(string name)
        {
            return await _categoryDAO.GetCategoryByName(name);
        }
    }
}