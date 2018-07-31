using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XamarinFormsMVP.Model.Repository.Interface
{
    public interface IRepository<T> where T : new()
    {
        IQueryable<T> AsQueryable();
        void Delete(T entity);
        void DeleteAll();
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> predicate = null);
        List<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        void Insert(T entity);
        void InsertAll(List<T> entity);
        void Update(T entity);
        void Update(Expression<Func<T, bool>> predicate);
        void UpdateAll(List<T> entity);
        void Write(Action action);
    }
}
