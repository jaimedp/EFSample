using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EFSample.DAL
{
    public abstract class EFRepositoryBase<T> : IRepository<T>
            where T : class
    {
        IDbSet<T> _set;
        DbContext _context;

        public EFRepositoryBase(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public T Add(T entity)
        {
            return _set.Add(entity);
        }

        public T Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                _set.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual T Single(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] eagerLoad)
        {
            return GetAllQuery(eagerLoad)
                .Where(criteria)
                .SingleOrDefault();
        }

        public virtual T First(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] eagerLoad)
        {
            return GetAllQuery(eagerLoad)
                .Where(criteria)
                .FirstOrDefault();
        }

        public abstract T GetById(int id, params Expression<Func<T, object>>[] eagerLoad);

        public virtual IEnumerable<T> GetAll(int first = 0, int pageSize = 50, params Expression<Func<T, object>>[] eagerLoad)
        {
            /// TODO incluir OrderBy, Skip y Take para paginar
            return GetAllQuery(eagerLoad)
                .ToList();
        }


        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> criteria, int first = 0, int pageSize = 50, params Expression<Func<T, object>>[] eagerLoad)
        {
            /// TODO incluir OrderBy, Skip y Take para paginar
            return GetAllQuery(eagerLoad).Where(criteria)
                .ToList();
        }

        protected virtual IQueryable<T> GetAllQuery(params Expression<Func<T, object>>[] eagerLoad)
        {
            if (eagerLoad != null && eagerLoad.Length > 0)
            {
                return  eagerLoad.Aggregate(_set.AsQueryable(), (c, i) => c.Include(i));
            }

            return _set;
        }
    }
}
