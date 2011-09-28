using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using SubRefactor.IRepository;
using SubRefactor.Repository.Infrastructure;

namespace SubRefactor.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private SubRefactorContext _dataContext;
        public readonly DbSet<T> dbSet;

        private IDatabaseFactory DatabaseFactory { get; set; }

        protected SubRefactorContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = DataContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual T Update(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Func<T, bool> where)
        {
            IEnumerable<T> objects = dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                dbSet.Remove(obj);
        }

        public virtual void Delete(int id)
        {
            var entity = FindById(id);
            if (entity == null) return;
            dbSet.Remove(entity);
        }

        public virtual T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T Find(Func<T, bool> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }        

        public virtual int Count()
        {
            return dbSet.Count();
        }

        public virtual int Count(Func<T, bool> where)
        {
            return dbSet.Count(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return dbSet.Where(where).ToList();
        }
    }
}
