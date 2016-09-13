﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Core.Repository
{
    /// <summary>
    /// Interface for a generic repository
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        Task Save();
    }
}
