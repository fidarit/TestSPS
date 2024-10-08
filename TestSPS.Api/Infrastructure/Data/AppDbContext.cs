using Microsoft.EntityFrameworkCore;
using TestSPS.Api.Domain.Entities;

namespace TestSPS.Api.Infrastructure.Data
{
    internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        internal DbSet<Product> Products => Set<Product>();
        internal DbSet<ProductVersion> ProductVersions => Set<ProductVersion>();
        internal DbSet<EventLog> EventLogs => Set<EventLog>();
    }
}
