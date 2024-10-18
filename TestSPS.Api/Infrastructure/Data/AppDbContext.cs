using Microsoft.EntityFrameworkCore;
using TestSPS.Api.Domain.Entities;

namespace TestSPS.Api.Infrastructure.Data
{
    internal class AppDbContext : DbContext
    {
        internal DbSet<Product> Products => Set<Product>();
        internal DbSet<ProductVersion> ProductVersions => Set<ProductVersion>();
        internal DbSet<EventLog> EventLogs => Set<EventLog>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
