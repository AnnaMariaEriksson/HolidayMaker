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

namespace HolidayMakerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HolidayMakerBackendContext _context;

        public HotelsController(HolidayMakerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet("{CityID}/{StartDate}/{EndDate}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel(int CityID,DateTimeOffset StartDate,DateTimeOffset EndDate)
        {
            ObservableCollection<Hotel> TempHotels = new ObservableCollection<Hotel>();
            ObservableCollection<Room> TempRooms = new ObservableCollection<Room>();
           await foreach(Hotel h in _context.Hotel)
            {
            foreach(Room r in _context.Room.Where(x => x.HotelID == h.HotelID))
            {
                    Booking booking = await _context.Booking.FirstOrDefaultAsync(b => b.roomID == r.ID);
                    if (booking != null)
                    {
                     
                        if (booking.StartDate < StartDate && booking.EndDate > EndDate)
                        {
                            TempRooms.Add(r);
                        }
                    }
                    else
                    {
                        TempRooms.Add(r);
                    }
            }
            if(TempRooms.Count > 0)
                {
                    if(h.CityID == CityID)
                    {
                        TempHotels.Add(h);
                    }
                    
                    TempRooms.Clear();
                }
            }
            if (TempHotels.Count() > 0)
            {
                return Ok(TempHotels);
            }
            else
            {
                return Ok(TempHotels);
            }
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.HotelID)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.HotelID }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.HotelID == id);
        }
    }
}
