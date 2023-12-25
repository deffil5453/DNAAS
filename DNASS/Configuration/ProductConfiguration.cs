using DNASS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNASS.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(product => product.OrdersProduct)
                .WithOne(orderProduct => orderProduct.Product)
                .HasForeignKey(orderProduct => orderProduct.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
