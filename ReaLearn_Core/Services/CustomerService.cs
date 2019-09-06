using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;
using ReaLearn_Core.Services.Abstract;

namespace ReaLearn_Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
      
        }


        public void AddCustomer(Customer customer)
        {
          _customerRepository.AddCustomer(customer);
            
        }

  
    }
}
