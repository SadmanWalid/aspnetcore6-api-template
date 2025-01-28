using PROJECT.Database.Database;
using PROJECT.IRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repository.Infrastructure
{
    public class UnitOfWork:IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
