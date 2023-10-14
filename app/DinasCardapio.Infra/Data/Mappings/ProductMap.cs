using DinasCardapio.Domain.Entities;
using DinasCardapio.Domain.Enums;
using DinasCardapio.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DinasCardapio.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30)
                .HasConversion(x => x.Title, x => new Name(x));

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("DECIMAL")
                .HasConversion(x => x.Value, x => new Price(x));

            builder.Property(x => x.UrlImage)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255)
                .HasConversion(x => x.Url, x => new ImageUrl(x));

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .HasConversion(x => x.ToString(), x => (EProductType) Enum.Parse(typeof(EProductType), x, true));

            builder.Property(x => x.Size)
                .HasColumnName("Size")
                .HasColumnType("VARCHAR");

            builder.Ignore(x => x.Notifications);

            builder.HasIndex(x => x.Name, "IX_Name")
                .IsUnique();
        }
    }
}
