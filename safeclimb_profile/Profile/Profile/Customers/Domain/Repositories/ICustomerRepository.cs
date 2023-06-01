using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Customers.Domain.Models;

namespace Go2Climb.API.Customers.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task AddAsync(Customer customer);
        Task<Customer> FindByIdAsync(int id);
        Customer FindById(int id);
        Task<Customer> FindByEmailAsync(string email);
        public bool ExistsByEmail(string email);
        void Update(Customer customer);
        void Remove(Customer customer);
    }
}