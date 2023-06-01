using AutoMapper;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Domain.Repositories;
using Go2Climb.API.Customers.Domain.Services;
using Go2Climb.API.Customers.Domain.Services.Communication;
using Go2Climb.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Go2Climb.API.Customers.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }
        
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.FindByIdAsync(id);
            if (customer == null) throw new KeyNotFoundException("Customer not found.");
            return customer;
        }
        

        public async Task<CustomerResponse> FindById(int id)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            return new CustomerResponse(existingCustomer);
        }
        
        //Helper method
        private Customer GetById(int id)
        {
            var customer = _customerRepository.FindById(id);
            if (customer == null) throw new KeyNotFoundException("Customer not found.");
            return customer;
        }
    }
}