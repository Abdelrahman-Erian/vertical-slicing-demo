using vertical_slicing_demo.Models;

namespace vertical_slicing_demo.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        Task SoftDeleteAsync(TEntity entity);
        Task HardDeleteAsync(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity?> GetByIDAsync(Guid id);
        Task<TEntity?> GetByIDWithTrackingAsync(Guid id);
        IQueryable<TEntity> GetAll();
        Task SaveChangesAsync();
    }
}
