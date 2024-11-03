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
        public Task<ProductLine> GetProductIdByInfor(int? productId, int? year, int? shelfId);

        Task CreateProductLine(ProductLine productLine);
        public Task<bool> ReduceProductLine(int productLineId, int? quantity);
        public Task<List<int?>> GetListManufacturingYearOfProduct(int? productId);
        Task<List<ProductLine>> GetProductLineListByProductId(int productId);
        Task<List<ProductLine>> GetProductLineForExport(int? productId, int? productYear);
        Task<int> CountQuantityForExport(int? productId, int? productYear);
        Task<bool> UpdateAsync(ProductLine productLine);
        Task<List<ProductLine>> GetProductLineListByProductId(int? productId);

    }
}
