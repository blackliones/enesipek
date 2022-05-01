using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
namespace Core.DataAccess
{
    //T CLASS OLMALI YANİ REFERANS OLMALI
    public interface IEntityRepository<T> where T : IEntity,new()
    { 
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
