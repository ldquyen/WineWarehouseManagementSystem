using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccessLayer;
using Repositories.Interface;

namespace Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDAO _accountDAO;

        public AccountRepository()
        {
            _accountDAO = AccountDAO.instance;
        }
        public async Task<Account?> Login(string username, string password)
        {
            Account? account = new Account();
            account = await _accountDAO.Login(username, password);
            return account;
        }
        public async Task<List<Account>> GetManagerAccount()
        {
            return await _accountDAO.GetManagerList();
        }
        public async Task<List<Account>> GetStaffList() => await _accountDAO.GetStaffList();
        public async Task CreateAccount(Account account)
        {
            await _accountDAO.CreateAccount(account);
        }
        public async Task UpdateAccount(Account account)
        {
            await _accountDAO.UpdataAccount(account);
        }

        public async Task<Account> GetAccountById(int accountID)
        {
            return await _accountDAO.GetAccountById(accountID);
        }

        public async Task<bool> CheckName(string accountName)
        {
            return await _accountDAO.CheckName(accountName);
        }
        public async Task<bool> CheckUsername(string username)
        {
            return await _accountDAO.CheckUsername(username);
        }
    }
}
