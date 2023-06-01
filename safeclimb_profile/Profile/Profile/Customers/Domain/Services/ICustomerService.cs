using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Domain.Services.Communication;
using Go2Climb.API.Customers.Services;
using Go2Climb.API.Security.Domain.Services.Communication;


namespace Go2Climb.API.Customers.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<Customer> GetByIdAsync(int id);
        Task RegisterAsync(RegisterCustomerRequest request);
        Task UpdateAsync(int id, UpdateCustomerRequest request);
        Task DeleteAsync(int id);
        Task<CustomerResponse> FindById(int id);
    }
}