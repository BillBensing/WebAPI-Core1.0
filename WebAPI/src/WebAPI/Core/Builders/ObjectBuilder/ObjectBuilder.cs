using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Builders.ObjectBuilder
{
    public abstract class ObjectBuilder<From, To> : IObjectBuilder<From, To>
    {
        public virtual To EmptyObject()
        {
            return Activator.CreateInstance<To>();
        }

        public virtual IQueryable<To> EmptyQueryable()
        {
            var result = new List<To>();
            return ((IEnumerable<To>)result).Select(x => x).AsQueryable();
        }

        public virtual IQueryable<To> ToQueryable(IQueryable<From> queryable)
        {
            var result = new List<To>();
            foreach (var item in queryable
                .Select(obj => ToObject(obj)))
            {
                result.Add(item);
            }
            return ((IEnumerable<To>)result).Select(x => x).AsQueryable();
        }

        public virtual To ToObject(From fromObject)
        {
            throw new NotImplementedException();
        }
    }
}
