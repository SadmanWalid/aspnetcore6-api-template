using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.IService.Infrastructure
{
    public interface IGenereicService<T> where T : class
    {
        bool AddAsync(T entity);
        bool UpdateAsync(T entity);
        bool DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
