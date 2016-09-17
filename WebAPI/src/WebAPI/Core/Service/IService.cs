using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Service
{
    public interface IService<T>
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task<IQueryable<T>> GetAll();
        Task Update(T entity);
    }
}