using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Entity;

namespace WebAPI.Core.Repository
{
    /// <summary>
    /// Generic repository base class
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;

        public Repository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return  _dbset.AsQueryable<T>();
        }

        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).AsQueryable();
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity) as T;
 
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity) as T;
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Save()
        {
            await _entities.SaveChangesAsync();
        }
    }
}