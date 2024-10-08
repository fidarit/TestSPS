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

}
