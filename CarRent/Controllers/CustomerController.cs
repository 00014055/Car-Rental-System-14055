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
    public class CustomerController : ControllerBase
    {
        private readonly CarRentDbContext _context;
        private readonly ICustomersRepository _customersRepository;

        public CustomerController(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        // GET: api/Cars 14055
        [HttpGet]
        public async Task<IEnumerable<Customers>> GetCustomer()
        {
            return await _customersRepository.GetAllCustomers();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            var customer = await _customersRepository.GetSingleCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5 14055
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            await _customersRepository.UpdateCustomers(customer);
            return NoContent();
        }

        // POST: api/Cars 14055
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers customer)
        {
            _customersRepository.CreateCustomers(customer);

            return CreatedAtAction("GetCustomers", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            _customersRepository.DeleteCustomers(id);

            return NoContent();
        }

    }
}

