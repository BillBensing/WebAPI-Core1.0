using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Entity;
using WebAPI.Core.Repository;

namespace WebAPI.Core.Service
{
    public abstract class AbstractService<T> : IService<T> where T : BaseEntity
    {
       protected readonly IRepository<T> _repository;

        /// <summary>
        /// Base logic for all Service inheritance
        /// </summary>
        /// <param name="repository">Generic Repository for an Entity</param>     
        public AbstractService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> Create(T entity)
        {
            var result = _repository.Add(entity);
            await _repository.Save();
            return result;
        }

        public virtual async Task<T> Read(int id)
        {
            var result = await _repository.Find(id);
            return result;     
        }

        public virtual async Task Update(T entity)
        {
            _repository.Edit(entity);
           await  _repository.Save();
        }

        public virtual async Task Delete(int id)
        {
            var entity = _repository.Find(id) as T;
            _repository.Delete(entity);
            await _repository.Save();
        }

    }
}
