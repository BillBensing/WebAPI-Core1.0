using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Entity;
using WebAPI.Core.Repository;

namespace WebAPI.Core.Service
{
    public abstract class Service<T> : IService<T> where T : BaseEntity
    {
       private readonly IRepository<T> _repository;

       public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _repository.Add(entity);
            await _repository.Save();
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _repository.Edit(entity);
           await  _repository.Save();
        }

        public virtual async Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            _repository.Delete(entity);
            await _repository.Save();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
