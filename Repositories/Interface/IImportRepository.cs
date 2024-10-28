using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IImportRepository
    {
        Task CreateImport(Import import);
        Task<List<Import>> GetImportList(DateOnly? StartDate, DateOnly? EndDate);
    }
}
