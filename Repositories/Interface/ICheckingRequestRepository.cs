using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICheckingRequestRepository
    {
        Task AddChecking(CheckingRequest checking);
        Task UpdateChecking(CheckingRequest checking);
        Task<List<CheckingRequest>> GetAllCheckingRequestsAsync();
        Task<List<CheckingRequest>> GetAllChecking();

        Task<List<CheckingRequest>> GetCheckingForStaff();
        Task<CheckingRequest> GetRequestByRequestId(int checkingRequestId);
    }
}
