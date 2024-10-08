using Microsoft.EntityFrameworkCore;
using TestSPS.Api.Domain.Entities;
using TestSPS.Api.Domain.Interfaces;
using TestSPS.Api.Infrastructure.Data;
using TestSPS.Api.Infrastructure.Data.Repositories;

namespace TestSPS.Api.Infrastructure
{
    public static class InfrastructureServiceEx
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<Product>, EfRepository<Product>>();
            services.AddScoped<IRepository<ProductVersion>, EfRepository<ProductVersion>>();
            services.AddScoped<IRepository<EventLog>, EfRepository<EventLog>>();
        }
    }
}
