using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Controller.Pagination
{
    public class PaginationHeader
    {
        /// <summary>
        /// The quantity of available records in the data set.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The quantity of pages available
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Http link to the next page of data
        /// </summary>
        public string NextPage { get; set; }

        /// <summary>
        /// Http link to the previous page of data
        /// </summary>
        public string PreviousPage { get; set; }
    }
}
