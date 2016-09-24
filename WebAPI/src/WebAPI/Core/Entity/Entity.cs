using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Entity
{
    public abstract class Entity<T> : AbstractEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
