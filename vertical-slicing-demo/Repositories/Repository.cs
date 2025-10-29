using Microsoft.EntityFrameworkCore;
using vertical_slicing_demo.Database;
using vertical_slicing_demo.Models;

namespace vertical_slicing_demo.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        AppDbContext _appDbContext;
        DbSet<TEntity> _dbSet;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _dbSet.AddAsync(entity);
        }

        public async Task HardDeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }
        public Task Update(TEntity entity)
        { 
            entity.UpdatedDate = DateTime.Now;
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task<TEntity?> GetByIDAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<TEntity?> GetByIDWithTrackingAsync(Guid id)
        {
            return await _dbSet
                .AsTracking()
                .FirstOrDefaultAsync(e => e.ID == id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().Where(e => !e.IsDeleted);
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
