using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Entity;

namespace WebAPI.Core.Repository
{
    public class Repository<T> : AbstractRepository<T> where T : Entity<int>
    {
        public Repository(DbContext context) : base(context)
        {
        }
    }
}
