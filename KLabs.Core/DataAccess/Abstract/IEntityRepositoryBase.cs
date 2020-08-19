using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KLabs.Entities.EntityBases.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<T>
    where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter, Expression<Func<T, object>>[] includes = null);

        T First();

        T GetLast(Expression<Func<T, bool>> filter=null, Expression<Func<T, object>>[] includes = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null);

        IEnumerable<T> GetListSkipTake(int skip,int take, Expression<Func<T, bool>> filter = null, Expression<Func<T, object>>[] includes = null);

        bool Any(Expression<Func<T, bool>> filter = null);

        int Count(Expression<Func<T, bool>> filter = null);

        bool SetState(T entity, EntityState state);

        IEntity SetStateEntity(IEntity entity, EntityState state);

    }
}