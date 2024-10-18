using Microsoft.EntityFrameworkCore;
using TestSPS.Api.Domain.Entities;
using TestSPS.Api.Domain.Interfaces;

namespace TestSPS.Api.Infrastructure.Data.Repositories
{
    internal class EfRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public IQueryable<T> AsQueryable => dbSet;

        public EfRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken)
        {
            await dbSet.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await dbSet.Where(t => t.ID == id).ExecuteDeleteAsync(cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbSet.FirstOrDefaultAsync(t => t.ID == id, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
