﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace ITGB.UIS.EF.Base
{
    public class EntityRepository<TContext, TObject> : IRepository<TObject>
            where TContext : DbContext
            where TObject : class
    {
        protected TContext context;
        protected DbSet<TObject> dbSet;
        protected bool IsOwnContext = true;

        public EntityRepository(TContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<TObject>();
        }

        /// <summary>
        /// Gets the data context object.
        /// </summary>
        protected virtual TContext Context { get { return context; } }

        /// <summary>
        /// Gets the current DbSet object.
        /// </summary>
        protected virtual DbSet<TObject> DbSet { get { return dbSet; } }

        /// <summary>
        /// Dispose the class.
        /// </summary>
        public void Dispose()
        {
            if ((IsOwnContext) && (Context != null))
                Context.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TObject> All()
        {
            return DbSet.AsQueryable();
        }

        /// <summary>
        /// Gets objects by specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate object.</param>
        /// <returns>return an object collection result.</returns>
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public virtual TObject Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TObject Create(TObject TObject)
        {
            var newEntry = DbSet.Add(TObject);
            if (IsOwnContext)
                Context.SaveChanges();
            return newEntry;
        }

        public virtual void Delete(TObject TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Remove(TObject);
            if (IsOwnContext)
                Context.SaveChanges();
        }

        public virtual TObject Update(TObject TObject)
        {
            var entry = Context.Entry(TObject);
            DbSet.Attach(TObject);
            entry.State = EntityState.Modified;
            if (IsOwnContext)
                Context.SaveChanges();
            return TObject;
        }

        public int Update(Expression<Func<TObject, bool>> predicate, Expression<Func<TObject, TObject>> updateExpression)
        {
            return DbSet.Where(predicate).Update(updateExpression);
        }

        public virtual int Delete(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).Delete();
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual int Count(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public int Submit()
        {
            return Context.SaveChanges();
        }

        public virtual void Clear()
        {

        }


        public List<TObject> Pager(IQueryable<TObject> query, int pageIndex, int pageSize, out int count)
        {
            var q1 = query.DeferredCount().FutureValue();
            var q2 = query.Skip(pageIndex * pageSize).Take(pageSize).Future();

            // 这里会触发上面所有Future函数中的查询包装到一个连接中执行
            count = q1.Value;

            //因为已经得到结果了，这里不会再次查询
            return q2.ToList();
        }
    }
}
