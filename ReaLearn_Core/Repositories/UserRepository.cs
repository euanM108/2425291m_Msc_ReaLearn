using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ReaLearn_Core.Data;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.ViewModels;
using ReaLearn_Core.Repositories.Abstract;

namespace ReaLearn_Core.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private ApplicationDbContext _context { get; set; }
        private UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> GetUsersWithCustomerId(int id)
        {
            return _context.Set<ApplicationUser>().Where(c => c.CustomerId == id);
        }

        public async Task<IdentityResult> AddUserAsync(ApplicationUser user, string Password)
        {
            var result = await _userManager.CreateAsync(user, Password);
            return result;
        }

        public ApplicationUser GetUser(string id)
        {
            return _context.Set<ApplicationUser>().Where(c => c.Id == id).FirstOrDefault();
        }

        public ApplicationUser GetUserWithEmail(string email)
        {
            return _context.Set<ApplicationUser>().Where(c => c.Email == email).FirstOrDefault();
        }

        public void UpdateUser(ApplicationUser updatedUser)
        {
            var result = _context.Set<ApplicationUser>().Where(c => c.Id == updatedUser.Id).FirstOrDefault();
            result.FirstName = updatedUser.FirstName;
            result.LastName = updatedUser.LastName;
            result.UserName = updatedUser.UserName;
            result.TimeStamp = DateTime.Now;
            _context.SaveChanges();
            
        }
    }
}
