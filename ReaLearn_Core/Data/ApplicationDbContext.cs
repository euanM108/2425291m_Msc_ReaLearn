using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReaLearn_Core.Models;
using ReaLearn_Core.Models.VRObjectModels;

namespace ReaLearn_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Customer> Customers { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<CourseUserRelation> CourseUserRelation { get; set; }
        DbSet<Scene> Scenes { get; set; }
        DbSet<VRObject> VRObject { get; set; }
        DbSet<VRHotspot> VRHotspot { get; set; }
        DbSet<VRQuestionCard> VRQuestionCard { get; set; }
        DbSet<VRQuestionResponse> VRQuestionResponse { get; set; }
        DbSet<VRBackground> VRBackground { get; set; }
        
    }
}
