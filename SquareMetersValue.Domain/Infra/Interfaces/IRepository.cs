using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SquareMetersValue.Domain.Infra.Interfaces
{
    public interface IRepository<TEntity, TType> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TType> GetById(Guid id);
        Task<IEnumerable<TType>> GetAll();
        Task<IEnumerable<TType>> GetByFilter(Expression<Func<TType, bool>> filter);
        void Update(TEntity obj);
        void Remove(Guid id);

    }
}
