using BusinessObject.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class ExportRepository : IExportRepository
    {
        private readonly ExportDAO _exportDAO;
        private readonly ExportDetailDAO _exportDetailDAO;

        public ExportRepository()
        {
            _exportDAO = ExportDAO.instance;
            _exportDetailDAO = ExportDetailDAO.instance;
        }
        public async Task<List<Export>> GetAllExportAsync()
        {
            return await _exportDAO.GetAllExports();
        }

        public async Task<List<Export>> GetExportByExportDateAsync(DateOnly exportDate)
        {
            return await _exportDAO.GetExportByExportDate(exportDate);
        }
        public async Task CreateExportAsync(Export export)
        {
            await _exportDAO.AddExport(export);
        }

        public async Task<dynamic> UpdateExportAsync(Export export)
        {
            int result = await _exportDAO.UpdateExport(export);
            return result;
        }

        public async Task DeleteExportAsync(int exportId)
        {
            await _exportDAO.DeleteExport(exportId);
        }

        
    }
}
