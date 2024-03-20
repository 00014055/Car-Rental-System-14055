using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRent.Data;
using CarRent.Models;
using CarRent.Repositories;

namespace CarRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarRentDbContext _context;
        private readonly ICarsRepository _carsRepository;

        public CarsController(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        // GET: api/Cars  14055
        [HttpGet]
        public async Task<IEnumerable<Car>> Getcars()
        {
            return await _carsRepository.GetAllCars();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _carsRepository.GetSingleCar(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5 14055
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            await _carsRepository.UpdateCar(car);
            return NoContent();
        }

        // POST: api/Cars 14055
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _carsRepository.CreateCar(car);

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            _carsRepository.DeleteCar(id);

            return NoContent();
        }

        //private bool CarExists(int id)
        //{
        //    return (_context.cars?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
