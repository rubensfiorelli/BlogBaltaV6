using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Category");

            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Title)
              .IsRequired()
              .HasColumnType("NVARCHAR")
              .HasMaxLength(80);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder
               .HasIndex(x => x.Slug, "IX_Category_Slug")
               .IsUnique();
        }
    }
}
