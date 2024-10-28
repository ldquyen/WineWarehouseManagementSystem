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
    public class ImportRepository : IImportRepository
    {
        private readonly ImportDAO _importDAO;
        public ImportRepository()
        {
            _importDAO = ImportDAO.instance;
        }
        public async Task CreateImport(Import import)
        {
            await _importDAO.AddImport(import);
        }

        public async Task<List<Import>> GetImportList(DateOnly? StartDate, DateOnly? EndDate)
        {
            return await _importDAO.GetImportList(StartDate, EndDate);
        }
    }
}
