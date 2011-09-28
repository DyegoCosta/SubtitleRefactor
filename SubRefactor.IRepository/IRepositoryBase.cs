using System;
using System.Collections.Generic;

namespace SubRefactor.IRepository
{
    public interface IRepositoryBase<T> 
        where T : class
    {
        T Add(T entity);
        T Update(T entity);

        void Delete(T entity);
        void Delete(Func<T, bool> predicate);
        void Delete(int id);

        T FindById(int Id);
        T Find(Func<T, Boolean> where);

        int Count();        
        int Count(Func<T, bool> where);

        IEnumerable<T> GetAll();        
        IEnumerable<T> GetMany(Func<T, bool> where);
    }
}
