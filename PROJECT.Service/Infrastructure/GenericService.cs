using PROJECT.IRepository.Infrastructure;
using PROJECT.IService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Service.Infrastructure
{
    public abstract class GenericService<T> : IGenereicService<T> where T : class
    {
        protected IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual bool AddAsync(T entity)
        {
            var success = _repository.AddAsync(entity);

            if(!success)
            {
                return false;
            }
            return true;
        }

        public bool DeleteAsync(T entity)
        {
          var success = _repository.DeleteAsync(entity);

            if (!success)
            {
                return false;
            }
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public bool UpdateAsync(T entity)
        {
            var success = _repository.UpdateAsync(entity);

            if(!success)
            {
                return false;
            }
            return true;
        }
    }
}
