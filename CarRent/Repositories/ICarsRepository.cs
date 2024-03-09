using CarRent.Models;

namespace CarRent.Repositories
{
    public interface ICarsRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetSingleCar(int id);
        Task CreateCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(int id);
    }
}
