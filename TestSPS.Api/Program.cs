using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSPS.Api.Domain.Entities;
using TestSPS.Api.Domain.Interfaces;
using TestSPS.Api.Infrastructure;

namespace TestSPS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureDbContext(builder);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.MapGet("/api/products", async ([FromQuery] string? filter, IRepository<Product> repository, CancellationToken token)
                =>
            {
                if (string.IsNullOrEmpty(filter))
                    return await repository.AsQueryable.ToListAsync(token);
                else
                    return await repository.AsQueryable.Where(t => t.Name.Contains(filter)).ToListAsync(token);
            });
            
            app.MapPost("/api/products", async ([FromBody] ProductRequest request, IRepository<Product> repository, CancellationToken token)
                => await repository.CreateAsync(new()
                {
                    Name = request.Name,
                    Description = request.Description,
                }, token));

            app.MapPut("/api/products/{id}", async (Guid id, [FromBody] ProductRequest request, IRepository<Product> repository, CancellationToken token)
                => await repository.UpdateAsync(new()
                {
                    ID = id,
                    Name = request.Name,
                    Description = request.Description,
                }, token));

            app.MapDelete("/api/products/{id}", async (Guid id, IRepository<Product> repository, CancellationToken token)
                => await repository.DeleteAsync(id, token));

            app.Run();
        }


        private static void ConfigureDbContext(WebApplicationBuilder builder)
        {
            const string paramName = "DbConnection";
            var connectionString = builder.Configuration.GetConnectionString(paramName);

            if (connectionString == null)
                throw new ArgumentOutOfRangeException(paramName);

            builder.Services.AddApplicationDbContext(connectionString);
        }
    }

    internal class ProductRequest
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
