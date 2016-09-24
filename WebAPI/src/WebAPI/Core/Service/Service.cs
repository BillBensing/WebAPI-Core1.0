using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Entity;
using WebAPI.Core.Repository;
using WebAPI.Core.Service.Decorator;

namespace WebAPI.Core.Service
{
    public class Service<T> : ServiceValidationDecorator<T> where T : BaseEntity
    {
        /// <summary>
        /// Implementation of all base Service Logic
        /// </summary>
        /// <param name="repository">Generic Repository for an Entity</param>
       public Service(IRepository<T> repository) : base (repository) { }
    }
}
