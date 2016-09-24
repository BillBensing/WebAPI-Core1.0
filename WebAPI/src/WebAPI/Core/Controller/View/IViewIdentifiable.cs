using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Controller.View
{
    public interface IViewIdentifiable<T>
    {
        T Id { get; set; }
    }
}
