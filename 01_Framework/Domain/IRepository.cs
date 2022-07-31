using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _01_Framework.Domain
{
    public interface IRepository<TKey, T>
    {
        void Create(T entity);
        T GetBy(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
