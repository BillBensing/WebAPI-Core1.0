using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Entity;
using WebAPI.Core.Errors;
using WebAPI.Core.Repository;

namespace WebAPI.Core.Service.Decorator
{
    public class ServiceValidationDecorator<T> : AbstractService<T> where T : AbstractEntity
    {
        /// <summary>
        /// Argument validation decorator for base service implementation
        /// </summary>
        /// <param name="repository">Entity Repository</param>
        
        public ServiceValidationDecorator(IRepository<T> repository) : base (repository) { }

        public override Task<T> Create(T entity)
        {
            ValidateNullEntity(entity);
            return base.Create(entity);
        }

        public override Task<T> Read(int id)
        {
            ValidateIntegerArgument(id);
            return base.Read(id);
        }

        public override Task Update(T entity)
        {
            ValidateNullEntity(entity);
            return base.Update(entity);
        }

        public override Task Delete(int id)
        {
            ValidateIntegerArgument(id);
            return base.Delete(id);
        }

        private void ValidateNullEntity(T entity)
        {
            if (entity == null)
            {
                string error = "The entity provided is null.";
                string message = string.Format(error + " {0} ", nameof(entity));
                throw new ServiceException(message);
            }
        }

        private void ValidateIntegerArgument(int arg)
        {
            if (arg <= 0)
            {
                string error = "The integer provided must be 1 or greater.";
                string message = string.Format(error + " {0} ", nameof(arg));
                throw new ServiceException(message);
            }
   
        }
    }
}