using Microsoft.EntityFrameworkCore;
using TestSPS.Api.Domain.Entities;

namespace TestSPS.Api.Infrastructure.Data
{
    internal class AppDbContext : DbContext
    {
        internal DbSet<Product> Product => Set<Product>();
        internal DbSet<ProductVersion> ProductVersion => Set<ProductVersion>();
        internal DbSet<EventLog> EventLog => Set<EventLog>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
