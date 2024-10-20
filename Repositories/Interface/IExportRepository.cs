using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IExportRepository
    {
        public Task<List<Export>> GetAllExportAsync();
        public Task<List<Export>> GetExportByExportDateAsync(DateOnly exportDate);
        public Task CreateExportAsync(Export export);
        public Task<dynamic> UpdateExportAsync(Export export);
        public Task DeleteExportAsync(int exportId);

    }
}
