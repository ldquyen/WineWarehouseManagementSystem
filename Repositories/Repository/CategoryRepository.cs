using BusinessObject.Models;
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

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _categoryDAO.GetCategoryById(categoryId);
        }
        public async Task<bool> CheckCategoryName(string categoryName)
        {
            return await _categoryDAO.CheckCategoryName(categoryName);
        }
        public async Task UpdateCategory(Category category)
        {
            await _categoryDAO.UpdateCategory(category);
        }
    }
}
