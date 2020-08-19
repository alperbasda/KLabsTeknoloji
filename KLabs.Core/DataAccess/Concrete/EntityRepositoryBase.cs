using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KLabs.Core.DataAccess.Abstract;
using KLabs.Entities.EntityBases.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Core.DataAccess.Concrete
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>>[] includes = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                
                if (includes != null)
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                return query.FirstOrDefault(filter);
            }
        }

        public TEntity First()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault();
            }
        }

        public TEntity GetLast(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                

                if (includes != null)
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                return filter == null ?
                 query.OrderByDescending(w => w.Id).FirstOrDefault() :
                 query.OrderByDescending(w => w.Id).FirstOrDefault(filter);
            }
        }


        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                
                if (includes != null)
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                return filter != null ? query.Where(filter).ToList() : query.ToList();
            }
        }

        public IEnumerable<TEntity> GetListSkipTake(int skip, int take, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>().OrderBy(s => s.Id);

                if (includes != null)
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                return filter != null ? query.Where(filter).Skip(skip).Take(take).ToList() : query.Skip(skip).Take(take).ToList();
            }
        }


        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Any(filter) : context.Set<TEntity>().Any();
            }
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter != null ? context.Set<TEntity>().Count(filter) : context.Set<TEntity>().Count();
            }
        }

        public bool SetState(TEntity entity, EntityState state)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = state;
                return context.SaveChanges() > 0;
            }
        }

        public IEntity SetStateEntity(IEntity entity, EntityState state)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = state;
                context.SaveChanges();
                return entity;
            }
        }
    }
}