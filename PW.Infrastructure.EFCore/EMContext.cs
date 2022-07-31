using Microsoft.EntityFrameworkCore;
using PW.Domain.Models;
using PW.Infrastructure.EFCore.Mapping;

namespace PW.Infrastructure.EFCore
{
    public class EMContext : DbContext
    {
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Files> Files { get; set; }

        public EMContext(DbContextOptions<EMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(CourseMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            

        }
    }
}
