using Microsoft.EntityFrameworkCore;
using Roulette.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Roulette.DAL.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RouletteContext RouletteContext { get; set; }
        public RepositoryBase(RouletteContext rouletteContext)
        {
            RouletteContext = rouletteContext;
        }
        public async Task<IQueryable<T>> FindAll()
        {
          return RouletteContext.Set<T>().AsNoTracking();
        }
        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RouletteContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task Create(T entity)
        {
            RouletteContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            RouletteContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            RouletteContext.Set<T>().Remove(entity);
        }
    }
}
