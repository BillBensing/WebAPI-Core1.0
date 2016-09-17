using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Entity;
using WebAPI.Core.Repository;

namespace WebAPI.Core.Service
{
    public abstract class Service<T> : IService<T> where T : BaseEntity
    {
       protected readonly IRepository<T> _repository;

       public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            var result = _repository.Add(entity);
            await _repository.Save();
            return result;
        }

        public virtual async Task<T> Read(int id)
        {
            if (id == 0) throw new ArgumentException();
            var result = await _repository.Find(id);
            return result;     
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _repository.Edit(entity);
           await  _repository.Save();
        }

        public virtual async Task Delete(int id)
        {
            if (id == null) throw new ArgumentNullException();
            var entity = _repository.Find(id) as T;
            _repository.Delete(entity);
            await _repository.Save();
        }

        public virtual async Task<IQueryable<T>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
