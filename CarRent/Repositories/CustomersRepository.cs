using CarRent.Data;
using CarRent.Data.Migrations;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly CarRentDbContext _dbContext;
        public CustomersRepository(CarRentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            var customers = await _dbContext.customer.ToListAsync();
            return customers;
        }

        public async Task<Customers> GetSingleCustomer(int id)
        {
            return await _dbContext.customer.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task CreateCustomers(Customers customer)
        {
            await _dbContext.customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomers(int id)
        {
            var customer = await _dbContext.customer.FirstOrDefaultAsync(b => b.Id == id);
            if (customer != null)
            {
                _dbContext.customer.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCustomers(Customers customer)
        {
            _dbContext.Entry(customer).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
