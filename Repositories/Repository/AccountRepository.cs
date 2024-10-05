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

    }
}
