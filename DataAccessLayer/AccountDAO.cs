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

        public async Task<List<Account>> GetManagerList()
        {
            return await _context.Accounts.Where(x => x.AccountRole == 2).AsNoTracking().ToListAsync();
        }
        public async Task<List<Account>> GetStaffList()
        {
            return await _context.Accounts.Where(x => x.AccountRole == 1).AsNoTracking().ToListAsync();
        }

        public async Task CreateAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckName(string accountName)
        {
            return await _context.Accounts.AnyAsync(x => x.AccountName == accountName);
        }
        public async Task<bool> CheckUsername(string userName)
        {
            return await _context.Accounts.AnyAsync(x => x.Username == userName);
        }

        public async Task UpdataAccount(Account account)
        {
            var acc = await _context.Accounts.FindAsync(account.AccountId);
            if (acc != null)
            {
                acc.AccountName = account.AccountName;
                acc.UserPassword = account.UserPassword;
                _context.Accounts.Update(acc);
                await _context.SaveChangesAsync();
            }
        }
    }
}
