using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories.Classes
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var result = await Context.Set<TEntity>().FindAsync(id);
            return result;
        }

        public async Task<TEntity> GetAsync(string name)
        {
            var result = await Context.Set<TEntity>().FindAsync(name);
            return result;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await Context.Set<TEntity>().ToListAsync();
            return result;
        }

        public virtual async  Task AddAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() => Context.Set<TEntity>().AddAsync(entity));            
        }


        public async Task RemoteAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() => Context.Set<TEntity>().Remove(entity));
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }


    }
}
