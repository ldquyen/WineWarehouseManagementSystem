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

        public async Task AddReport(Report report)
        {
            await _reportDAO.AddReportAsync(report);
        }

        public async Task UpdateReport(Report report)
        {
            await _reportDAO.UpdateReportAsync(report);
        }

        public async Task DeleteReport(int reportId)
        {
            await _reportDAO.DeleteReportAsync(reportId);
        }

        public async Task<List<Report>> GetAllReports()
        {
            return await _reportDAO.GetAllReportsAsync();
        }

        public async Task<Report> GetReportById(int reportId)
        {
            return await _reportDAO.GetReportByIdAsync(reportId);
        }
    }
}
