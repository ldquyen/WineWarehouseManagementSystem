using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BrewingRoomDAO : SingletonBase<BrewingRoomDAO>
    {
        public async Task AddBrewingRoom(BrewingRoom brewingRoom)
        {
            await _context.BrewingRooms.AddAsync(brewingRoom);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrewingRoom(BrewingRoom brewingRoom)
        {
            _context.BrewingRooms.Update(brewingRoom);
            await _context.SaveChangesAsync();
        }
    }
}
