using PW.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PW.Infrastructure.EFCore.Mapping
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professors");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Family);
            builder.Property(x => x.ImgAddress);
            builder.Property(x => x.Level);
            builder.Property(x => x.LinkedInURL);
            builder.Property(x => x.MapAddress);
            builder.Property(x => x.Address);
            builder.Property(x => x.Email);
            builder.Property(x => x.Tel);
        }
    }
}
