using PW.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PW.Infrastructure.EFCore.Mapping
{
    public class ResumeMapping : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.ToTable("Resumes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.FromYear);
            builder.Property(x => x.ToYear);
            builder.Property(x => x.Description);
            builder.Property(x => x.Priority);
            builder.Property(x => x.Icon);
            builder.Property(x => x.Status);
        }
    }
}
