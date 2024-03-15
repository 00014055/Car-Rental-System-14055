using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data
{
    public class CarRentDbContext: DbContext
    {
        public CarRentDbContext(DbContextOptions<CarRentDbContext> options) : base(options) { }
        public DbSet<Car> cars { get; set; }
        public DbSet<Customers> customer { get; set; }
    }
}
