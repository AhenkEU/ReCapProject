using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);// Herhangi bir bilgiye göre tek bir elemanı getirme. T döndürecek.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

       

    }
}
