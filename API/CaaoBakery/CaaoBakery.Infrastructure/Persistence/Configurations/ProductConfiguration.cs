using CaaoBakery.Domain.ProductAggregate;
using CaaoBakery.Domain.ProductAggregate.Enums;
using CaaoBakery.Domain.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaaoBakery.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureStocksTable(builder);
            ConfigureProductsTable(builder);
        }

        private static void ConfigureStocksTable(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsMany(p => p.Stocks, sb =>
            {
                sb.ToTable("Stocks");

                sb.WithOwner().HasForeignKey("ProductId");

                sb.HasKey("Id", "ProductId");

                sb.Property(s => s.Id)
                    .HasColumnName("StockId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => StockId.Create(value));

                sb.Property(s => s.Quantity)
                    .HasColumnName("Quantity");
                sb.Property(s => s.ProductionDateTime)
                    .HasColumnName("ProductionDateTime");
                sb.Property(s => s.ExpirationDateTime)
                    .HasColumnName("ExpirationDateTime");

                sb.Property(r => r.Status)
                    .HasConversion(
                        status => status.Value,
                        value => StockStatus.FromValue(value));

            });
        }

        private static void ConfigureProductsTable(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ProductId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(100);
            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,4)");

            builder.OwnsOne(m => m.AverageRating);

        }
    }
}
