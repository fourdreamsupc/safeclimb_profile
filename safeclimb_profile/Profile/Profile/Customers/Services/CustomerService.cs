using AutoMapper;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Customers.Domain.Repositories;
using Go2Climb.API.Customers.Domain.Services;
using Go2Climb.API.Customers.Domain.Services.Communication;
using Go2Climb.API.Security.Domain.Services.Communication;
using Go2Climb.API.Security.Exceptions;
using Go2Climb.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Go2Climb.API.Customers.Services
{
    public class CustomerService : ICustomerService
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

        public async Task RegisterAsync(RegisterCustomerRequest request)
        {
            //Validate
            if (_customerRepository.ExistsByEmail(request.Email))
                throw new AppException($"Email {request.Email} is already taken.");
            
            //Map request to customer
            var customer = _mapper.Map<Customer>(request);
            
            //Hash Password
            customer.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            //Save customer
            //Console.WriteLine($"{customer}");
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the customer: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateCustomerRequest request)
        {
            var customer = GetById(id);
        
            //Validate
            if(_customerRepository.ExistsByEmail(request.Email)){
                Console.WriteLine(customer.Email);
                var customerWithSameEmail = await _customerRepository.FindByEmailAsync(request.Email);
                if (customerWithSameEmail.Id != id){
                    Console.WriteLine("im in");
                    throw new AppException($"Email {request.Email} is already taken.");
                }
            } 
            
            //Hash Password if entered
            if (!string.IsNullOrEmpty(request.Password))
                customer.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            //Map request to Customer
            _mapper.Map(request, customer);
            
            try
            {
                _customerRepository.Update(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the customer: {e.Message}");
            }
        }

        public async Task<CustomerResponse> FindById(int id)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new CustomerResponse("Customer not found.");

            return new CustomerResponse(existingCustomer);
        }

        public async Task DeleteAsync(int id)
        {
            var customer = GetById(id);

            try
            {
                _customerRepository.Remove(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the customer: {e.Message}");
            }
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