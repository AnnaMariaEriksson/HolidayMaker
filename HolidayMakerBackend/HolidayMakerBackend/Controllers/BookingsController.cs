using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayMakerBackend.Data;
using HolidayMakerBackend.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HolidayMakerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly HolidayMakerBackendContext _context;

        public BookingsController(HolidayMakerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
            return await _context.Booking.ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingID)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(PostBooking postBooking)
        {
            foreach (Room r in postBooking.BookingRooms)
            {
                Booking booking = new Booking()
                {
                    roomID = r.ID,
                    StartDate = postBooking.StartDate,
                    EndDate = postBooking.EndDate,
                    UserID = postBooking.UserID,
                    PhoneNumber = postBooking.PhoneNumber,
                    Adress = postBooking.Adress,
                    BookingID = 0
                };
                _context.Booking.Add(booking);

            }

            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                return BadRequest();
            }

            return Ok();

            //Booking booking = new Booking();
            //booking.roomID = postBooking.BookingRooms[0].ID;
            //booking.BookingID = 0;
            //booking.EndDate = postBooking.EndDate;
            //booking.StartDate = postBooking.StartDate;
            //booking.UserID = postBooking.UserID;
            //_context.Booking.Add(booking);
            //try
            //{
            //    var result = await _context.SaveChangesAsync();
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //}
            //return Ok(); CTRL + K, CTRL + C
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
            public async Task<ActionResult<Booking>> DeleteBooking(int id)
            {
                var booking = await _context.Booking.FindAsync(id);
                if (booking == null)
                {
                    return NotFound();
                }

                _context.Booking.Remove(booking);
                await _context.SaveChangesAsync();

                return booking;
            }

            private bool BookingExists(int id)
            {
                return _context.Booking.Any(e => e.BookingID == id);
            }
        }
    }
