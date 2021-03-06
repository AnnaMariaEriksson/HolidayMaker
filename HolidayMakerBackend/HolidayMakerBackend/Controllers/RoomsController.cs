﻿using System;
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
using SQLitePCL;

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
        [HttpGet("{HotelId}/{sorrtby}/{StartDate}/{EndDate}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms(int HotelId,int sorrtby,DateTimeOffset StartDate,DateTimeOffset EndDate)
        {
            ObservableCollection<Room> rooms = new ObservableCollection<Room>();
           
            List<Booking> bookings = new List<Booking>();
            var test = _context.Room.Where(x => x.HotelID == HotelId).ToList();
            List<Room> TempRooms = new List<Room>();
            foreach (Room r in test)
            {
               
                bookings = _context.Booking.Where(b => b.BookedRoomID == r.ID ).ToList();
                if (bookings.Count() != 0)
                {
                    foreach (var b in bookings)
                    {
                        if (b.StartDate < StartDate && b.EndDate < StartDate || b.StartDate > EndDate && b.EndDate > StartDate)
                        {
                            TempRooms.RemoveAll(x => x.ID == r.ID);
                            TempRooms.Add(r);

                        }
                        else
                        {
                            TempRooms.RemoveAll(x => x.ID == r.ID);
                            break;
                        }
                    }
                }
                else { TempRooms.Add(r); }
            }

           

            if (sorrtby == 1)
            {
                rooms = new ObservableCollection<Room>(TempRooms.OrderBy(r => r.Price));
            }
            else if (sorrtby == 2)
            {
                rooms = new ObservableCollection<Room>(TempRooms.OrderByDescending(r => r.Price));
            }

            return rooms;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.ID)
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

            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
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
            return _context.Room.Any(e => e.ID == id);
        }
    }
}
