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
        
        Task UpdateReport(Report report);

        Task<bool> AddReports(List<Report> reportList);
        Task<List<Report>> GetReportNotComplete(int checkingReqId);
        Task<List<Report>> GetReportNotCompleteByAccountID(int? accountId);

        Task<Report> GetReportByReportId(int reportId);
        Task<List<Report>> GetReportListById(int reportId);
        Task<List<Report>> GetReportListByCheckingId(int checkingId);
        Task<List<Report>> GetReportListToUpdateForAdmin();
    }
}
