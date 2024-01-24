using Arch.Core.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arch.Infra.Data.Sql.Commands.Orders.Configs;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Set the table name (optional)
        builder.ToTable("Orders");

        // Configure primary key
        builder.HasKey(o => o.BusinessId);

        // Configure fields
        builder.Property(o => o.BusinessId)
            .IsRequired();

        builder.OwnsOne(o => o.UserId, userId =>
        {
            userId.Property(u => u.Value)
                .HasColumnName("UserId")
                .IsRequired();
        });

        builder.OwnsOne(o => o.Address, address =>
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

        // Configure any indexes
        builder.HasIndex(o => o.UserId.Value)
            .IsUnique(false);

        // Configure any indexes
        builder.HasIndex(o => o.Address.Street)
            .IsUnique(false);
    }
}
