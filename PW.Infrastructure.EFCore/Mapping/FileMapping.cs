using PW.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PW.Infrastructure.EFCore.Mapping
{
    public class FilesMapping : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.ToTable("Files");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FileName);
            builder.Property(x => x.FileTypeId);
            builder.Property(x => x.Description);
            builder.Property(x => x.UploadDate);
            builder.Property(x => x.CourseId);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Course).WithMany(x => x.Files).HasForeignKey(x => x.CourseId);
        }
    }

}
