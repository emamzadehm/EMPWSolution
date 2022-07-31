using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PW.Domain.Models;

namespace PW.Infrastructure.EFCore.Mapping
{
    public class TestimonialMapping : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StudentName);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.UniversityName);
            builder.Property(x => x.CourseName);
            builder.Property(x => x.EduYear);
            builder.Property(x => x.IsVisible);
            builder.Property(x => x.StudentEmail);
            builder.Property(x => x.StudentImg);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.Status);
        }
    }
}
