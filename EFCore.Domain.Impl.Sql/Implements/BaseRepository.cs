using EFCore.Domain.Impl.Sql.Context;
using EFCore.Domain.Interfaces;
using EFCore.Domain.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace EFCore.Domain.Impl.Sql.Implements
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;
        public BaseRepository(IServiceProvider serviceProvider)
        {
            _appDbContext = serviceProvider.GetRequiredService<AppDbContext>();
        }

        public void Add(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            _appDbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteMany(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = this.Find(predicate);
            _appDbContext.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAll(FindOptions? findOptions)
        {
            return this.Get(findOptions);
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return this.Get(findOptions).Where(predicate).FirstOrDefault()!;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return this.Get(findOptions).Where(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _appDbContext.Set<TEntity>().Any(predicate);
        }
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _appDbContext.Set<TEntity>().Count(predicate);
        }

        /// <summary>
        /// Chỉ thật sự cần asynchronous khi save change 
        /// Các operation ở trên chỉ thực hiện thay đổi ở DbContext chứ chưa apply với CSDL
        /// </summary>
        /// <returns></returns>
        public async Task SaveChange()
        {
            await _appDbContext.SaveChangesAsync();
        }

        private DbSet<TEntity> Get(FindOptions? findOptions = null)
        {
            findOptions ??= new FindOptions();
            var entity = _appDbContext.Set<TEntity>();
            if (findOptions.IsAsNoTracking && findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes().AsNoTracking();
            }
            else if (findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes();
            }
            else if (findOptions.IsAsNoTracking)
            {
                entity.AsNoTracking();
            }
            return entity;
        }
    }
}
