using System.Linq;
using KLabs.Core.DataAccess.Abstract;
using KLabs.Entities.EntityBases.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Core.DataAccess.Concrete
{
    public class QueryableRepositoryBase<T> : IQueryableRepositoryBase<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public QueryableRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => Entities;

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

    }
}