using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Controller.View
{
    public interface IViewUpdateHistory
    {
        DateTime UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}
