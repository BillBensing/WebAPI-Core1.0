using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Core.Errors
{
    public class RepositoryException : Exception
    {

        public RepositoryException(string message) : base(message){ }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
