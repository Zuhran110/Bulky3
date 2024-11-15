using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }

        void IRepository<T>.Add(T entity)
        {
            DbSet.Add(entity);
        }

        void IRepository<T>.Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        void IRepository<T>.DeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange();
        }

        T IRepository<T>.Get(Expression<Func<T, bool>> Filter)
        {
            IQueryable<T> query = DbSet;
            query = query.Where(Filter);
            return query.FirstOrDefault();
        }

        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }
    }
}

