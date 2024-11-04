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
    public class CheckingRequestRepository : ICheckingRequestRepository
    {
        private readonly CheckingRequestDAO _checkingRequestDAO;
        public CheckingRequestRepository()
        {
            _checkingRequestDAO = CheckingRequestDAO.instance;
        }
        public async Task AddChecking(CheckingRequest checking)
        {
            await _checkingRequestDAO.AddChecking(checking);
        }
        public async Task UpdateChecking(CheckingRequest checking)
        {
            await _checkingRequestDAO.UpdateChecking(checking);
        }
        public async Task<List<CheckingRequest>> GetAllCheckingRequestsAsync()
        {
            return await _checkingRequestDAO.GetAllCheckingRequestsAsync();
        }

        public async Task<List<CheckingRequest>> GetAllChecking()
        {
            return await _checkingRequestDAO.GetAlls();
        }

        public async Task<List<CheckingRequest>> GetCheckingForStaff()
        {
            return await _checkingRequestDAO.GetCheckingForStaff();
        }

        public async Task<CheckingRequest> GetRequestByRequestId(int checkingRequestId)
        {
            return await _checkingRequestDAO.GetRequestByRequestId(checkingRequestId);
        }

    }
}
