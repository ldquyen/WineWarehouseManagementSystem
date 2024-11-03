using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BrewingRoomDAO : SingletonBase<BrewingRoomDAO>
    {

        public async Task<dynamic> AddBrewingRoom(BrewingRoom brewingRoom)
        {
            try
            {
                await _context.BrewingRooms.AddAsync(brewingRoom);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error at ExportDAO: {ex.Message}");
            }
        }
        public async Task UpdateBrewingRoom(BrewingRoom brewingRoom)
        {
            _context.BrewingRooms.Update(brewingRoom);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBrewingRoomAsync(BrewingRoom brewingRoom)
        {
            var room = await _context.BrewingRooms.FindAsync(brewingRoom.BrewingRoomId);
            if (room != null)
            {
                room.RoomName = brewingRoom.RoomName;
                room.Note = brewingRoom.Note;
                room.Temperature = brewingRoom.Temperature;
                room.Humidity = brewingRoom.Humidity;
                // _context.Update(room);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<BrewingRoom>> GetAllRoomAsync()
        {
            return await _context.BrewingRooms.ToListAsync();
        }

        public async Task<List<BrewingRoom>> GetBrewingsByRoomNameAsync(string roomName)
        {
            return await _context.BrewingRooms.Where(x => x.RoomName.Contains(roomName)).ToListAsync();
        }
        public async Task<BrewingRoom> GetBrewingByRoomNameAsync(string roomName)
        {
            return await _context.BrewingRooms.FirstOrDefaultAsync(br => br.RoomName == roomName);
        }
        public async Task<BrewingRoom> GetBrewingRoomById(int roomId)
        {
            return await _context.BrewingRooms.FirstOrDefaultAsync(br => br.BrewingRoomId == roomId);
        }
    }
}
