using CarRent.Data;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly CarRentDbContext _dbContext;
        public CarsRepository(CarRentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var cars = await _dbContext.cars.ToListAsync();
            return cars;
        }

        public async Task<Car> GetSingleCar(int id)
        {
            return await _dbContext.cars.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task CreateCar(Car car)
        {
            await _dbContext.cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCar(int id)
        {
            var car = await _dbContext.cars.FirstOrDefaultAsync(b => b.Id == id);
            if ( car != null)
            {
                _dbContext.cars.Remove(car);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateCar(Car car)
        {
            _dbContext.Entry(car).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
