using Microsoft.AspNetCore.Identity;
using ReaLearn_Core.Data;
using ReaLearn_Core.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaLearn_Core.Repositories
{
    public class RoleRepository : Repository<IdentityRole>, IRoleRepository
    {
        private ApplicationDbContext _context { get; set; }

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
