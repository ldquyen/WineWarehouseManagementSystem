using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task<List<Product>> GetAll();
        Task<List<Product>> GetProductByName(string name);
        public Task<Product> GetProductById(int? id);
        public Task<List<Product>> GetListOfProduct();
    }
}
