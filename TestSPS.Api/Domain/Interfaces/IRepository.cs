using TestSPS.Api.Domain.Entities;

namespace TestSPS.Api.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> AsQueryable { get; }

        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
