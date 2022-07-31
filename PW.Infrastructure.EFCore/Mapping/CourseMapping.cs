using PW.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PW.Infrastructure.EFCore.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ShowInWebSite);
            builder.Property(x => x.Status);
        }
    }
}
