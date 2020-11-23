using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaintBook.Content.Domain.PostAndPostInfo.Model;

namespace PaintBook.Content.Infrastructure.EF.EntityConfigurations
{
    class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {


            builder.ToTable("Post").HasKey(c => c.Id);
            builder.Property(p => p.Id).HasColumnName("PostID").ValueGeneratedNever();
            builder.Property(p => p.PostInfo).HasMaxLength(100)
                    .HasConversion(p => p.Value, p => PostInfo.Create(p).Value);
            builder.Ignore(b => b.DomainEvents);

        }
    }
}
