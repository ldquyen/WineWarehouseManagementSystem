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
    public class ImportDetailRepository : IImportDetailRepository
    {
        private readonly ImportDetailDAO _importDetailDAO;

        public ImportDetailRepository()
        {
            _importDetailDAO = ImportDetailDAO.instance;
        }
        public async Task CreateImportDetail(ImportDetail importDetail)
        {
            await _importDetailDAO.AddImportDetail(importDetail);
        }
    }
}
