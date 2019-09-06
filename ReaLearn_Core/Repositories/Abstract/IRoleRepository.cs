using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories.Abstract
{
    public interface IRoleRepository : IRepository<IdentityRole>
    {
    }
}
