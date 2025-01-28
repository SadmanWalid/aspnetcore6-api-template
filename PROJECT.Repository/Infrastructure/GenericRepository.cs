using Microsoft.EntityFrameworkCore;
using PROJECT.Database.Database;
using PROJECT.IRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repository.Infrastructure
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _dbContext;
        public DbSet<T> Table 
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        protected GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        public virtual bool AddAsync(T entity)
        {
            Table.AddAsync(entity);
            return true;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if(entity == null)
            {
                return null;
            }
            return entity;
        }
        public bool UpdateAsync(T entity)
        {
            Table.Update(entity);
            return true;
        }

        public bool DeleteAsync(T entity)
        {
            Table.Remove(entity);
            return true;
        }

        public virtual async Task<ICollection<T>> GetAsync()
        {
            return await Table.ToListAsync();
        }
    }
}
