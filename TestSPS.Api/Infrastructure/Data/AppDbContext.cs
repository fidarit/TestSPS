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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .ToTable(tb =>
                {
                    tb.HasTrigger("Trigger_Product_Delete");
                    tb.HasTrigger("Trigger_Product_Insert");
                    tb.HasTrigger("Trigger_Product_Update");
                });

            modelBuilder
                .Entity<ProductVersion>()
                .ToTable(tb =>
                {
                    tb.HasTrigger("Trigger_ProductVersion_Delete");
                    tb.HasTrigger("Trigger_ProductVersion_Insert");
                    tb.HasTrigger("Trigger_ProductVersion_Update");
                });
        }
    }
}
