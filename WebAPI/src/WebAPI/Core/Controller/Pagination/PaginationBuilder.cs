using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Controller.Pagination
{
    public class PaginationBuilder<T> : IPaginationBuilder<T>
    {

        IQueryable<T> data;
        string sort;
        int page;
        int pageSize;

        public virtual IQueryable<T> Build(HttpResponse response, IUrlHelper urlHelper, string routeName)
        {

            var totalPages = CalculateTotalPages(data, pageSize);

            var pageHeader = new PaginationHeader()
            {
                Count = data.Count(),
                Pages = totalPages,
                PreviousPage = CreatePreviousPageLink(urlHelper, routeName, sort, page, pageSize),
                NextPage = CreateNextPageLink(urlHelper, routeName, sort, page, pageSize, totalPages),
            };

            response.Headers.Add("X-Pagination", SerializeResponseHeader(pageHeader));

            var result = PaginateData(data, page, pageSize);
            return result;
        }

        /// <summary>
        /// Assings the variables
        /// </summary>
        /// <param name="sort">The sort parameters</param>
        /// <param name="page">The page being requested</param>
        /// <param name="pageSize">The page size limit</param>
        /// <returns></returns>
        public virtual PaginationBuilder<T> Use(string sort, int page, int pageSize)
        {
            this.sort = sort;
            this.page = page;
            this.pageSize = pageSize;
            return this;
        }

        /// <summary>
        /// Assigns the IQueryable data to paginate
        /// </summary>
        /// <param name="data">IQueryable data</param>
        /// <returns></returns>
        public virtual PaginationBuilder<T> ApplyToData(IQueryable<T> data)
        {
            this.data = data;
            return this;
        }

        /// <summary>
        /// Apply pagination to the IQueryable Data
        /// </summary>
        /// <param name="data">IQueryable object of data to paginate</param>
        /// <returns>Paginated IQueryable</returns>
        private IQueryable<T> PaginateData(IQueryable<T> data, int page, int pageSize)
        {
            return data?.Skip(pageSize * page).Take(pageSize);
        }

        /// <summary>
        /// Calulates the number of pages based update the data and size of pages
        /// </summary>
        /// <param name="data">IQueryable of data</param>
        /// <param name="pageSize">The size of pages</param>
        /// <returns>Count of total pages</returns>
        private int CalculateTotalPages(IQueryable<T> data, int pageSize)
        {
            var totalCount = data.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            return totalPages;
        }

        /// <summary>
        /// Creates a link for the previous page of an IQueryable data set
        /// </summary>
        /// <param name="urlHelper">IUrlHelper for the consuming Controller</param>
        /// <param name="routeName">Name of the Controller route</param>
        /// <param name="sort">Sort parameters from a request</param>
        /// <param name="page">Page number from a request</param>
        /// <param name="pageSize">Page size froma request</param>
        /// <returns>Previous page link url</returns>
        private string CreatePreviousPageLink(IUrlHelper urlHelper, string routeName, string sort, int page, int pageSize)
        {
            var prev = string.Empty;
            if (page > 0)
            {
                prev = urlHelper.RouteUrl(
                    routeName,
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort
                    });
            }
            return prev;
        }

        /// <summary>
        /// Creates a link for the next page of an IQueryable data set
        /// </summary>
        /// <param name="urlHelper">IUrlHelper for the consuming Controller</param>
        /// <param name="routeName">Name of the Controller route</param>
        /// <param name="sort">Sort parameters from a request</param>
        /// <param name="page">Page number from a request</param>
        /// <param name="pageSize">Page size froma request</param>
        /// <param name="totalPages">The total pages for the IQueryable dataset</param>
        /// <returns>Next page link url</returns>
        private string CreateNextPageLink(IUrlHelper urlHelper, string routeName, string sort, int page, int pageSize, int totalPages)
        {
            var next = string.Empty;
            if (page < (totalPages - 1))
            {
                next = urlHelper.RouteUrl(
                    routeName,
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort
                    });
            }
            return next;
        }

        /// <summary>
        /// Serializes the pagination header as a JSON String
        /// </summary>
        /// <param name="header"></param>
        /// <returns>JSON Serialized string</returns>
        private string SerializeResponseHeader(PaginationHeader header)
        {
            var result = JsonConvert.SerializeObject(header);
            return result;
        }

    }
}
