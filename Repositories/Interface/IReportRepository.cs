using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IReportRepository
    {
        Task AddReport(Report report);
        Task UpdateReport(Report report);
        Task DeleteReport(int reportId);
        Task<List<Report>> GetAllReports();
        Task<Report> GetReportById(int reportId);
    }
}
