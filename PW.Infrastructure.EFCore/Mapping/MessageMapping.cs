using PW.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PW.Infrastructure.EFCore.Mapping
{
    public class MessageMapping : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.IsEmailed);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.Status);
        }
    }
}