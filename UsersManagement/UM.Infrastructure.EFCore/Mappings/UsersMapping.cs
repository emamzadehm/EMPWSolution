using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UM.Domain.UsersAgg;

namespace UM.Infrastructure.EFCore.Mappings
{
    public class UsersMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Tbl_Users");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Tel).HasMaxLength(200).IsRequired(false);
            builder.Property(x => x.IMG).HasMaxLength(2000).IsRequired(false);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Status);

            builder.HasMany(x => x.UserRoles).WithOne(x => x.Users).HasForeignKey(x => x.UserID);

            //builder.OwnsMany(x => x.Roles, navigationBuilder =>
            //{
            //    navigationBuilder.HasKey(x => x.ID);
            //    navigationBuilder.ToTable("Tbl_Users_Roles");
            //    //navigationBuilder.Ignore(x => x.Name);
            //    navigationBuilder.WithOwner(x => x.Users);
            //    navigationBuilder.OwnsMany(x => x.Permissions, navigationBuilder1 =>
            //     {
            //         navigationBuilder1.HasKey(x => x.ID);
            //         navigationBuilder1.ToTable("Tbl_Role_Permission");
            //         //navigationBuilder.Ignore(x => x.Name);
            //         navigationBuilder1.WithOwner(x => x.Roles);
            //     });
            //});


            //builder.HasOne<Candidate>(x=>x.Candidates).WithOne(x=>x.Users).HasForeignKey<Candidate>(x=>x.ID);
            //builder.HasOne<Instructor>(x => x.Instructors).WithOne(x => x.Users).HasForeignKey<Instructor>(x => x.ID);
        }
    }
}
