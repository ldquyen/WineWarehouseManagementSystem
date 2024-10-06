using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountDAO : SingletonBase<AccountDAO>
    {
        public async Task<Account?> Login(string username, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Username == username && x.UserPassword == password);
            if (account == null) return null;
            return account;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountById(int accountID)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountID);
        }
    }
}
