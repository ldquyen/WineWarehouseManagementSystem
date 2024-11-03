using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IBrewingRoomRepository
    {
        public Task<List<BrewingRoom>> GetAllRoomAsync();
        public Task<List<BrewingRoom>> GetBrewingByRoomNameAsync(string roomName);
        public Task<BrewingRoom> GetBrewingRoomById(int roomId);
        public Task UpdateBrewingRoomAsync(BrewingRoom brewingRoom);
        public Task<dynamic> CreateBrewingRoomAsync(BrewingRoom brewingRoom);
    }
}
