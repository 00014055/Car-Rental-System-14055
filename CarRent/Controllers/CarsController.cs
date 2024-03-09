using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRentDbContext _context;

        public CarsController(CarRentDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Getcars()
        {
          if (_context.cars == null)
          {
              return NotFound();
          }
            return await _context.cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
          if (_context.cars == null)
          {
              return NotFound();
          }
            var car = await _context.cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
          if (_context.cars == null)
          {
              return Problem("Entity set 'CarRentDbContext.cars'  is null.");
          }
            _context.cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.cars == null)
            {
                return NotFound();
            }
            var car = await _context.cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
