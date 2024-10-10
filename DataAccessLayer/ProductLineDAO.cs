using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductLineDAO : SingletonBase<ProductLineDAO>
    {
        public async Task CreateProductLine(ProductLine productLine)
        {
            await _context.AddAsync(productLine);   
            await _context.SaveChangesAsync();
        }
    }
}
