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
        public Task<List<ProductLine>> GetProductLineListByProductId(int? productId);
        Task<List<ProductLine>> GetProductLineListByProductId(int productId);
<<<<<<< HEAD
        Task<List<ProductLine>> GetProductLineListByProductId(int? productId);

=======
        public Task<ProductLine> GetProductLineByProductLineId(int? productLineId);

        Task<List<ProductLine>> GetProductLineForExport(int? productId, int? productYear);
        Task<int> CountQuantityForExport(int? productId, int? productYear);
        Task<bool> UpdateAsync(ProductLine productLine);
>>>>>>> 9c2004ea2fd3bbccf5f75dbc8f7f318b6a4391b0
    }
}
