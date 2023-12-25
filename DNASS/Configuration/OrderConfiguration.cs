using DNASS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNASS.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(order=>order.OrdersProduct)
                .WithOne(orderProduct=>orderProduct.Order)
                .HasForeignKey(orderProduct=>orderProduct.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
