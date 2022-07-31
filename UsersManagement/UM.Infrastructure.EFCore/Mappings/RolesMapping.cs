using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UM.Domain.UsersAgg;

namespace UM.Infrastructure.EFCore.Mappings
{
    public class RolesMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Tbl_Roles");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.RoleName).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.Status);

            //builder.HasMany(x => x.UsersRoless).WithOne(x => x.Roles).HasForeignKey(x => x.RoleID);

        }
    }
}
