using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UM.Domain.UsersAgg;

namespace UM.Infrastructure.EFCore.Mappings
{
    public class UsersRolesMapping : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("Tbl_Users_Roles");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID);
            builder.Property(x => x.RoleID);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Users).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Roles).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleID);

        }
    }
}
