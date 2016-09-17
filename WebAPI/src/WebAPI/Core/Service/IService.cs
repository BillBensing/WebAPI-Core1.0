using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Service
{
    public interface IService<T>
    {
        Task<T> Create(T entity);
        Task<T> Read(int id);
        Task Update(T entity);
        Task Delete(int id);
        Task<IQueryable<T>> GetAll();
    }
}