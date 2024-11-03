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
    public class BrewingRoomRepository : IBrewingRoomRepository
    {
        private readonly BrewingRoomDAO _roomDAO;

        public BrewingRoomRepository()
        {
            _roomDAO = BrewingRoomDAO.instance;
        }
        public async Task<List<BrewingRoom>> GetAllRoomAsync() => await _roomDAO.GetAllRoomAsync();
        public async Task<List<BrewingRoom>> GetBrewingByRoomNameAsync(string roomName) => await _roomDAO.GetBrewingByRoomNameAsync(roomName);
        public async Task<BrewingRoom> GetBrewingRoomById(int roomId) => await _roomDAO.GetBrewingRoomById(roomId);
        public async Task UpdateBrewingRoomAsync(BrewingRoom brewingRoom) => await _roomDAO.UpdateBrewingRoomAsync(brewingRoom);

        public async Task<dynamic> CreateBrewingRoomAsync(BrewingRoom brewingRoom) => await _roomDAO.AddBrewingRoom(brewingRoom);
    }
}
