using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EFSample.DAL
{
    public interface IRepository<T>  where T : class
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        void Save();

        T Single(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] eagerLoad);
        T First(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] eagerLoad);
        T GetById(int id, params Expression<Func<T, object>>[] eagerLoad);
        IEnumerable<T> GetAll(int first = 0, int pageSize = 50, params Expression<Func<T, object>>[] eagerLoad);
        IEnumerable<T> Find(Expression<Func<T, bool>> criteria, int first = 0, int pageSize = 50, params Expression<Func<T, object>>[] eagerLoad);
    }
}
