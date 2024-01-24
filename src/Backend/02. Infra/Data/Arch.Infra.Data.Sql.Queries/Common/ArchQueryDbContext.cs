using Arch.Infra.Data.Sql.Queries.Orders;
using Microsoft.EntityFrameworkCore;
using Zamin.Infra.Data.Sql.Queries;

namespace Arch.Infra.Data.Sql.Queries.Common
{
    public class ArchQueryDbContext : BaseQueryDbContext
    {
        public ArchQueryDbContext(DbContextOptions<ArchQueryDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    }
}