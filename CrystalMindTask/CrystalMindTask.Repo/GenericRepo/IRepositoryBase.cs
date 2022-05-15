using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTask.Repo
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(Expression<Func<T, object>> include);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteBy(Expression<Func<T, bool>> expression);
        void DeleteBy(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include);
    }
}
