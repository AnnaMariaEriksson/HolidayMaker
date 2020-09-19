using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayMakerBackend.Data;
using HolidayMakerBackend.Models;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Routing;

namespace HolidayMakerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly HolidayMakerBackendContext _context;

        public RoomsController(HolidayMakerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Rooms/HotelId
        [HttpGet("{HotelId}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(int HotelId,int sorrtby)
        {
            if()
          ObservableCollection<Room> TempRooms = new ObservableCollection<Room>();        
                  await foreach(Room r in _context.Room)
                    {
                        if(r.HotelID == HotelId)
                        TempRooms.Add(r);
                    }
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
            for (int i = 1; i <= TempRooms.Count(); i++)
            {   
                if (TempRooms[i].Price >= TempRooms[i + 1].Price)
                {
                    rooms.Add(TempRooms[i]);
                    rooms.Add(TempRooms[i + 1]);
                }
                else
                {
                    rooms.Add(TempRooms[i + 1]);
                    rooms.Add(TempRooms[i]);
                }
            }
            return rooms;



            return TempRooms;
        }

        //// GET: api/Rooms/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Room>> GetRoom(int id)
        //{
        //    var room = await _context.Room.FindAsync(id);

        //    if (room == null)
        //    {
        //        return NotFound();
        //    }

        //    return room;
        //}

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.RoomID)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.RoomID }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Room.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomID == id);
        }
    }
}
