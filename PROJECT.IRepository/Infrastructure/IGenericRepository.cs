using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.IRepository.Infrastructure
{
    public  interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        bool AddAsync(T entity);
        bool UpdateAsync(T entity);
        bool DeleteAsync(T entity);
    }
}
