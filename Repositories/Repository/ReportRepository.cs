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
    public class ReportRepository : IReportRepository
    {
        private readonly ReportDAO _reportDAO;

  
        public ReportRepository()
        {
            _reportDAO = ReportDAO.instance;
        }

        public async Task UpdateReport(Report report)
        {
            await _reportDAO.UpdateReportForCheck(report);
        }

        public async Task<bool> AddReports(List<Report> reportList)
        {
            return await _reportDAO.AddReports(reportList);
        }

        public async Task<List<Report>> GetReportNotComplete(int checkingReqId)
        {
            return await _reportDAO.GetReportNotComplete(checkingReqId);
        }

        public async Task<List<Report>> GetReportNotCompleteByAccountID(int? accountId)
        {
            return await _reportDAO.GetReportNotComplete(accountId);
        }

        public async Task<Report> GetReportByReportId(int reportId)
        {
            return await _reportDAO.GetReportById(reportId);
        }
        

        public async Task<List<Report>> GetReportListById(int reportId)
        {
            return await _reportDAO.GetReportListById(reportId);
        }

        public async Task<List<Report>> GetReportListByCheckingId(int checkingId)
        {
            return await _reportDAO.GetReportListByCheckingId(checkingId);
        }
    }
}
