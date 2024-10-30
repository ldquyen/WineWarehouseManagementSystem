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
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository()
        {
            _productDAO = ProductDAO.instance;
        }
        public async Task CreateProduct(Product product)
        {
            await _productDAO.AddProduct(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productDAO.GetAllProduct();
        }

        public async Task<List<Product>> GetProductByName(string name)
        {
            return await _productDAO.GetProductByName(name);
        }
        public async Task<Product> GetProductById(int? id) => await _productDAO.GetProductById(id);
        public async Task<List<Product>> GetListOfProduct() => await _productDAO.GetListOfProduct();
    }
}
