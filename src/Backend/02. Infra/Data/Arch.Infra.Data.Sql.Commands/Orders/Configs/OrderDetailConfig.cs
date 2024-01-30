using Arch.Core.Domain.Orders.Entities;
using Arch.Core.Domain.Orders.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zamin.Infra.Data.Sql.Commands.ValueConversions;

namespace Arch.Infra.Data.Sql.Commands.Orders.Configs;

public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property(o => o.OrderId)
            .IsRequired();

        builder.Property(o => o.ProductId)
            .HasConversion<BusinessIdConversion>()
            .IsRequired();

        builder.Property(o => o.Count)
            .HasConversion(o => o.Value, o => Count.FromInt(o))
            .IsRequired();

        builder.HasOne(o => o.Order)
            .WithMany(o => o.OrderDetails)
            .HasPrincipalKey(o => o.Id)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
