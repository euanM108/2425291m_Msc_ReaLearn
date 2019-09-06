using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReaLearn_Core.Data;
using ReaLearn_Core.Models;
using ReaLearn_Core.Repositories.Abstract;

namespace ReaLearn_Core.Repositories
{

    public class CustomerRepository : Repository<ApplicationUser>, ICustomerRepository
    {
        private ApplicationDbContext _context { get; set; }

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
  
        public void AddCustomer(Customer customer)
        {
            _context.Set<Customer>().Add(customer);
            _context.SaveChanges();
        }

    }

}
