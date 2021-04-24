using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechSolution.Business.Models;

namespace TechSolution.Business.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> GetById(Guid id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> expression);

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(Guid id);
    }
}
