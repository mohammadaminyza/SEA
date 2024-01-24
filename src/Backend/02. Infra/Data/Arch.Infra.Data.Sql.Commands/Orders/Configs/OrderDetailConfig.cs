using Arch.Core.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arch.Infra.Data.Sql.Commands.Orders.Configs;

public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        // Set the table name (optional)
        builder.ToTable("OrderDetails");

        // Configure primary key
        builder.HasKey(od => od.BusinessId);

        // Configure fields
        builder.Property(od => od.BusinessId)
            .IsRequired();

        builder.OwnsOne(od => od.OrderId, orderId =>
        {
            orderId.Property(o => o.Value)
                .HasColumnName("OrderId")
                .IsRequired();
        });

        builder.OwnsOne(od => od.ProductId, productId =>
        {
            productId.Property(p => p.Value)
                .HasColumnName("ProductId")
                .IsRequired();
        });

        builder.OwnsOne(od => od.Count, count =>
        {
            count.Property(c => c.Value)
                .HasColumnName("Count")
                .IsRequired();
        });
    }
}
