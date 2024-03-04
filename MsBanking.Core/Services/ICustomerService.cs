using MsBanking.Common.Entity;

namespace MsBanking.Core.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(int id);
    }
}