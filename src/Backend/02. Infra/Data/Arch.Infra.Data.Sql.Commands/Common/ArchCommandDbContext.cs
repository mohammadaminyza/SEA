using Arch.Core.Domain.Orders.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Zamin.Extensions.Events.Outbox.Dal.EF;

namespace Arch.Infra.Data.Sql.Commands.Common
{
    public class ArchCommandDbContext : BaseOutboxCommandDbContext
    {
        public ArchCommandDbContext(DbContextOptions<ArchCommandDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var property = entityType.FindProperty("BusinessId");
                if (property != null)
                {
                    // Directly using Fluent API to ignore the 'BusinessId' property
                    builder.Entity(entityType.ClrType).Ignore("BusinessId");
                }
            }

            base.OnModelCreating(builder);
        }
    }
}