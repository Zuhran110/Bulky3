﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class  
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> Filter);
        void Delete(T entity);
        void Add(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
