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
    }
}
