using Arch.Core.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zamin.Infra.Data.Sql.Commands.ValueConversions;

namespace Arch.Infra.Data.Sql.Commands.Orders.Configs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.UserId)
            .HasConversion<BusinessIdConversion>()
            .IsRequired();

        builder.ComplexProperty(o => o.Address, address =>
        {
            address.Property(a => a.Street)
                .HasColumnName("Street")
                .IsRequired();

            address.Property(a => a.Plaque)
                .HasColumnName("Plaque")
                .IsRequired();
        });

        // Configure relationships
        builder.HasMany(o => o.OrderDetails)
            .WithOne() // Assuming OrderDetail has a reference back to Order
            .HasForeignKey(o => o.OrderId) // Assuming foreign key name in OrderDetail
            .HasPrincipalKey(o => o.BusinessId) // Assuming foreign key name in OrderDetail
            .IsRequired();
    }
}
