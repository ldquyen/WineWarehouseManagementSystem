﻿using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CheckingRequestDAO : SingletonBase<CheckingRequestDAO>
    {
        public async Task AddChecking(CheckingRequest checking)
        {
            await _context.CheckingRequests.AddAsync(checking);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateChecking(CheckingRequest checking)
        {
            _context.CheckingRequests.Update(checking);
            await _context.SaveChangesAsync();
        }
        public async Task<List<CheckingRequest>> GetAllCheckingRequestsAsync()
        {
            return await _context.CheckingRequests.ToListAsync();
        }

        public async Task<List<CheckingRequest>> GetAlls()
        {
            return _context.CheckingRequests.ToList();  
        }
    }
}
