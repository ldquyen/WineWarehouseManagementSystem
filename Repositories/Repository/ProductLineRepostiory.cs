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
    public class ProductLineRepostiory : IProductLineRepostiory
    {
        private readonly ProductLineDAO _productLineDAO;

        public ProductLineRepostiory()
        {
            _productLineDAO = ProductLineDAO.instance;
        }

        public async Task<ProductLine> GetProductIdByInfor(int? productId, int? year, int? shelfId) => await _productLineDAO.GetProductIdByInfor(productId, year, shelfId);

        public async Task CreateProductLine(ProductLine productLine)
        {
            await _productLineDAO.CreateProductLine(productLine);
        }
        public async Task<bool> ReduceProductLine(int productLineId, int? quantity) => await _productLineDAO.ReduceProductLine(productLineId, quantity);
        public async Task<List<int?>> GetListManufacturingYearOfProduct(int? productId) => await _productLineDAO.GetListManufacturingYearOfProduct(productId);

        public async Task<List<ProductLine>> GetProductLineListByProductId(int? productId) => await _productLineDAO.GetProductLineListByProductId(productId);
        public async Task<List<ProductLine>> GetProductLineListByProductId(int productId)
        {
            return await _productLineDAO.GetProductLineListByProductId(productId);
        }
<<<<<<< HEAD
        public async Task<ProductLine> GetProductLineByProductLineId(int? productLineId) => await _productLineDAO.GetProductLineByProductLineId(productLineId);


        public async Task<List<ProductLine>> GetProductLineForExport(int? productId, int? productYear)
        {
            return await _productLineDAO.GetProductLineForExport(productId, productYear);
        }
        public async Task<int> CountQuantityForExport(int? productId, int? productYear)
        {
            return await _productLineDAO.CountQuantityForExport(productId, productYear);
        }

        public async Task<bool> UpdateAsync(ProductLine productLine)
        {
            return await _productLineDAO.UpdateAsync(productLine);
=======
        public async Task<List<ProductLine>> GetProductLineListByProductId(int? productId)
        {
            return await _productLineDAO.GetProductLineListByProductId(productId);
>>>>>>> dev-hoang
        }
    }
}
