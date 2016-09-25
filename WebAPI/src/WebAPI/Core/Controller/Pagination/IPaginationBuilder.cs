using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Controller.Pagination
{
    public interface IPaginationBuilder<T>
    {
        PaginationBuilder<T> Use(string sort, int page, int pageSize);
        PaginationBuilder<T> ApplyToData(IQueryable<T> data);
        IQueryable<T> Build(HttpResponse response, IUrlHelper urlHelper, string routeName);
    }
}
