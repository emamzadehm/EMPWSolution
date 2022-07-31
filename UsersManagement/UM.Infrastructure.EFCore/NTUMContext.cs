using Microsoft.EntityFrameworkCore;
using UM.Domain.UsersAgg;
using UM.Infrastructure.EFCore.Mappings;

namespace UM.Infrastructure.EFCore
{
    public class UMContext:DbContext
    {

        public DbSet<User> Tbl_Users { get; set; }
        public DbSet<Role> Tbl_Roles { get; set; }
        public DbSet<UserRole> Tbl_Users_Roles { get; set; }

        public UMContext(DbContextOptions<UMContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(UsersMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}
