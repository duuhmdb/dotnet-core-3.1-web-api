using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;
using TechSolution.Data.Context;

namespace TechSolution.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : Entity, new()
    {
        protected readonly TechSolutionDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(TechSolutionDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var entity = new T { Id = id };
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        async Task SaveChanges() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(_context);
        }
    }
}
