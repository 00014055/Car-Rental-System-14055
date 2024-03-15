using CarRent.Models;

namespace CarRent.Repositories
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customers>> GetAllCustomers();
        Task<Customers> GetSingleCustomer(int id);
        Task CreateCustomers(Customers Customer);
        Task UpdateCustomers(Customers Customer);
        Task DeleteCustomers(int id);
    }
}
