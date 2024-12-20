﻿using BusinessObject.Models;
using DataAccessLayer;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public  class ExportDetailRepository : IExportDetailRepository
    {
        private readonly ExportDetailDAO _detailDAO;

        public ExportDetailRepository()
        {
            _detailDAO = ExportDetailDAO.instance;
        }

        public async Task<dynamic> CreateExportDetailsAsync(ExportDetail exportDetails)
        {
            return await _detailDAO.AddExportDetail(exportDetails);
        }
        public async Task<ExportDetail> GetExportDetailsById(int exportDetailsId)
        {
            return await _detailDAO.GetExportDetailsById(exportDetailsId);
        }
        public async Task<dynamic> UpdateExportDetailsAsync(int exportDetailId) 
        {
            ExportDetail detail = await _detailDAO.GetExportDetailsById(exportDetailId);
            if (detail == null)
            {
                return "This export detail cannot find";
            }
            int result = await _detailDAO.UpdateExportDetail(detail);
            return result;
        }

        public async Task DeleteExportDetailAsync(int exportDetailId)
        {
            await _detailDAO.DeleteExportDetails(exportDetailId);
        }

        public async Task<List<ExportDetail>> GetExportDetailsByExportId(int exportId)
        {
            return await _detailDAO.GetExportDetailsByExportId(exportId);
        }


    }
}
