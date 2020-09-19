using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolidayMakerBackend.Data;
using HolidayMakerBackend.Models;

namespace HolidayMakerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly HolidayMakerBackendContext _context;

        public CitiesController(HolidayMakerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCity()
        {
            var cities = await _context.City
                .Include(c => c.Hotels)
                .ThenInclude(c => c.Rooms)
                .ToListAsync();

            return Ok(cities);

            //return await _context.Region.ToListAsync();
        }

        // GET: api/Cities
        [HttpGet("{RegionID}")]

    public async Task<ActionResult<IEnumerable<City>>> GetCity(int regionID, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            ObservableCollection<City> tempCities = new ObservableCollection<City>();
            //TODO add dates
            //TODO include Hotels?

            await foreach (City city in _context.City)
            {
                if (city.CityID == regionID)
                {
                    tempCities.Add(city);
                }
            }
            
            return tempCities;

            //return await _context.City.ToListAsync();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _context.City.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.CityID)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _context.City.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.CityID }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.City.Remove(city);
            await _context.SaveChangesAsync();

            return city;
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.CityID == id);
        }
    }
}
