using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XamarinFormsMVP.Model.Repository.Interface;

namespace XamarinFormsMVP.Model.Repository
{
    public class Repository<T> : IRepository<T> where T : RealmObject, new()
    {
        protected readonly Realm _realm;

        public Repository()
        {
            _realm = Realm.GetInstance(RepositoryMigration.CurrentConfiguration);
        }

        public IQueryable<T> AsQueryable() =>
            _realm.All<T>().AsQueryable();

        public List<T> Get() =>
            _realm.All<T>().ToList();

        public IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _realm.All<T>().AsQueryable();
            return _realm.All<T>().Where(predicate).AsQueryable();
        }

        public List<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _realm.All<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy(orderBy);

            return query.ToList();
        }

        public T Get(int id) =>
            _realm.Find<T>(id);

        public T Get(string id) =>
            _realm.Find<T>(id);

        public T Get(Expression<Func<T, bool>> predicate) =>
            _realm.All<T>().FirstOrDefault(predicate);

        public void Insert(T entity)
        {
            _realm.Write(() =>
            {
                _realm.Add(entity);
            });
        }

        public void InsertAll(List<T> entities)
        {
            _realm.Write(() =>
            {
                if (entities == null || !entities.Any()) return;
                foreach (var entity in entities)
                {
                    _realm.Add(entity);
                }
            });
        }

        public void Update(T entity) =>
             _realm.Write(() => _realm.Add(entity, true));
        public void Update(Expression<Func<T, bool>> predicate)
        {

            if (predicate != null)
            {
                var query = _realm.All<T>();
                var obj = query.FirstOrDefault(predicate);
                if (obj != null)
                {
                    _realm.Write(() => _realm.Add(obj, true));
                }
            }
        }

        public void Write(Action action)
        {
            _realm.Write(action);
        }

        public void UpdateAll(List<T> entities)
        {
            _realm.Write(() =>
            {
                if (entities == null || !entities.Any()) return;
                foreach (var entity in entities)
                {
                    _realm.Add(entity, true);
                }
            });
        }

        public void Delete(T entity) =>
             _realm.Write(() => _realm.Remove(entity));

        public void Delete(IQueryable<T> entity) =>
             _realm.Write(() => _realm.RemoveRange<T>(entity));

        public void DeleteAll()
        {
            _realm.Write(() => _realm.RemoveAll<T>());
        }
    }

    public class RepositoryMigration
    {
        public static RealmConfiguration CurrentConfiguration =>
            new RealmConfiguration
            {
                SchemaVersion = 2
            };
    }
}