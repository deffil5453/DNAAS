using DNASS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNASS.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(orderProduct => new { orderProduct.OrderId, orderProduct.ProductId });
            builder.HasOne(orderProduct => orderProduct.Order).WithMany(orderProduct => orderProduct.OrdersProduct).HasForeignKey(orderProduct=>orderProduct.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(orderProduct => orderProduct.Product).WithMany(orderProduct => orderProduct.OrdersProduct).HasForeignKey(orderProduct => orderProduct.ProductId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
