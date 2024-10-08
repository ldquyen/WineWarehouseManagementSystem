using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<List<Category>> GetAlls();
        Task<List<Category>> GetCategoryByName(string name);
    }
}
