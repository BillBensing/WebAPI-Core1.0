using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Builders.ObjectBuilder
{
    public interface IObjectBuilder<FromType, ToType>
    {
        ToType ToObject(FromType fromObject);
        ToType EmptyObject();
        IQueryable<ToType> EmptyQueryable();
        IQueryable<ToType> ToQueryable(IQueryable<FromType> queryable);
    }
}
