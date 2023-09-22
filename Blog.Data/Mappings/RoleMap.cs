using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder
                  .ToTable("Role");

            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Name)
              .IsRequired()
              .HasColumnType("NVARCHAR")
              .HasMaxLength(80);

            builder.Property(x => x.Slug)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(80);

            builder
               .HasIndex(x => x.Slug, "IX_Role_Slug")
                   .IsUnique();


        }
    }
}
