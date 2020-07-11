using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly SchoolContext _schoolContext;
        private readonly DbSet<T> _dbSet;

        public Repository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
            _dbSet = schoolContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            var entry = _schoolContext.Entry(entity);
            entry.State = EntityState.Modified;
            _schoolContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsQueryable();
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public void Commit()
        {
            _schoolContext.SaveChanges();
        }
    }
}
