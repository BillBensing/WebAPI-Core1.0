using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Controller.Pagination
{

    public class PaginationBuilderValidation<T> : PaginationBuilder<T>
    {
        /// <summary>
        /// Validates that sort is not null, pages are not negative, and pagesize is not less than 1.
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public override PaginationBuilder<T> Use(string sort, int page, int pageSize)
        {

            if (sort == null)
            {
                throw new ArgumentNullException(nameof(sort));
            }
            if (page < 0)
            {
                throw new InvalidDataException(nameof(page));
            }
            if (pageSize < 1)
            {
                throw new InvalidDataException(nameof(pageSize));
            }

            return base.Use(sort, page, pageSize);
        }

        /// <summary>
        /// Validates the the IQueryable parameter is not null
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override PaginationBuilder<T> ApplyToData(IQueryable<T> data)
        {

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return base.ApplyToData(data);
        }

        public override IQueryable<T> Build(HttpResponse response, IUrlHelper urlHelper, string routeName)
        {

            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            if (urlHelper == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            if (string.IsNullOrEmpty(routeName))
            {
                throw new InvalidDataException(nameof(response));
            }

            return base.Build(response, urlHelper, routeName);
        }
    }
}
