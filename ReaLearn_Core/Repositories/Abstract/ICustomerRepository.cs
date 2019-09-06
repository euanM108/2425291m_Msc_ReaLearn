using Microsoft.EntityFrameworkCore;
using ReaLearn_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface ICustomerRepository : IRepository<ApplicationUser>
    {

        void AddCustomer(Customer customer);
    }
}
