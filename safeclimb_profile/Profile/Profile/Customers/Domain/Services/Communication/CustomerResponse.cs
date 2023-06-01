using System.Runtime.CompilerServices;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Shared.Domain.Services.Communication;

namespace Go2Climb.API.Customers.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        
        public CustomerResponse(Customer customer) : base(customer) {}

        public CustomerResponse(string message) : base(message) {}
    }
}