using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using _01_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _01_Framework.Infrastructure.EFCore
{
    public class BaseRepository<TKey, T> : IRepository<TKey, T> where T:class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context) 
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _context.Find<T>(id);
        }
    }
}
