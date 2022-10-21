using Microsoft.EntityFrameworkCore;
using OlineStore.Contrats.Interfaces.Repositories;
using System.Linq.Expressions;

namespace OnlineStore.Infraestructura.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T:class,new()
    {
        private readonly GestoresDbContext  _gestoresDbContext;

        public BaseRepository(GestoresDbContext gestoresDbContext)
        {
            _gestoresDbContext = gestoresDbContext;
        }

        public virtual IQueryable<T> GetAll() { var entitySet = _gestoresDbContext.Set<T>(); return entitySet.AsQueryable(); }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate) { return GetAll().FirstOrDefault(predicate)!; }

        public virtual Task<T> GetFirst(Expression<Func<T, bool>> predicate) { return GetAll().FirstOrDefaultAsync(predicate)!; }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) { return GetAll().Where(predicate); }

        public async Task Add(T entity)
        {
            var UpdatedAt = entity.GetType().GetProperty("UpdatedAt"); if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.UtcNow);

            var CreatedAt = entity.GetType().GetProperty("CreatedAt"); if (CreatedAt != null) entity.GetType().GetProperty("CreatedAt")?.SetValue(entity, DateTime.UtcNow);

            await _gestoresDbContext.AddAsync(entity); _gestoresDbContext.Entry(entity).State = EntityState.Added; await _gestoresDbContext.SaveChangesAsync();
        }

        public async Task AddRange(List<T> entity) { _gestoresDbContext.AddRange(entity); await _gestoresDbContext.SaveChangesAsync(); }

        public async Task Delete(T entity) { _gestoresDbContext.Remove(entity); await _gestoresDbContext.SaveChangesAsync(); }

        public async Task DeleteRange(List<T> entity) { _gestoresDbContext.RemoveRange(entity); await _gestoresDbContext.SaveChangesAsync(); }

        public async Task Update(T entity)
        {
            var UpdatedAt = entity.GetType().GetProperty("UpdatedAt"); if (UpdatedAt != null) entity.GetType().GetProperty("UpdatedAt")?.SetValue(entity, DateTime.UtcNow);

            _gestoresDbContext.Update(entity); await _gestoresDbContext.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> entity) { _gestoresDbContext.UpdateRange(entity); await _gestoresDbContext.SaveChangesAsync(); }


    }
}
