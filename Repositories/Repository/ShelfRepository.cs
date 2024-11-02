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
    public class ShelfRepository : IShelfRepository
    {
        private readonly ShelfDAO _shelfDAO;

        public ShelfRepository()
        {
            _shelfDAO = ShelfDAO.instance;
        }
        public async Task<List<Shelf>> GetAllShelf()
        {
            return await _shelfDAO.GetShelfList();
        }

        public async Task<bool> AddShelfQuantity(int? shelfid, int? quantity)
        {
            return await _shelfDAO.AddShelfQuantity(shelfid, quantity);
        }
        public async Task<bool> ReduceShelfQuantity(int? shelfId, int? quantity) => await _shelfDAO.ReduceShelfQuantity(shelfId, quantity);
        public async Task<List<Shelf>> GetShelfsOfProductLineByProductId(int? productId) => await _shelfDAO.GetShelfsOfProductLineByProductId(productId);

        public async Task<Shelf> GetShelfByShelfId(int? shelfId) => await _shelfDAO.GetShelfByShelfId(shelfId);
    }
}
