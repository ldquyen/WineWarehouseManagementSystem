using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<Account?> Login(string username, string password);
        Task<List<Account>> GetManagerAccount();
        Task CreateAccount(Account account);
        Task UpdateAccount(Account account);
        Task<Account> GetAccountById(int accountID);
        Task<bool> CheckName(string accountName);
        Task<bool> CheckUsername(string username);
    }
}

