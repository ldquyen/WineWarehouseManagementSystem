using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IProductLineRepostiory
    {
        Task CreateProductLine(ProductLine productLine);
        public Task<bool> ReduceProductLine(int productLineId, int quantity);
        public Task<List<int?>> GetListManufacturingYearOfProduct(int? productId);
        public Task<List<ProductLine>> GetProductLineListByProductId(int? productId);
        Task<List<ProductLine>> GetProductLineListByProductId(int productId);
    }
}
