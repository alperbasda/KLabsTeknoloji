using System.Linq;
using KLabs.Entities.EntityBases.Abstract;

namespace KLabs.Core.DataAccess.Abstract
{
    public interface IQueryableRepositoryBase<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }

    }
}