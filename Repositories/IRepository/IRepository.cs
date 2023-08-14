using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
namespace EmailWebApplication.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        //void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
