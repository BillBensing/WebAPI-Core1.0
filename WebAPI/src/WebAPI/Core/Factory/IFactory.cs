using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Factory
{
    public interface IFactory<T>
    {
        T Create(Enum selection);
    }
}
