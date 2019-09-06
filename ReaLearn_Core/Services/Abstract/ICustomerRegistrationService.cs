using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Services.Abstract
{
    public interface ICustomerRegistrationService
    {
        Task<IdentityResult> RegisterCustomerAsync(RegisterCustomerViewModel model);
  
    }
}
