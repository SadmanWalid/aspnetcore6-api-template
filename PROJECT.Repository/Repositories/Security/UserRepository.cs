using PROJECT.Database.Database;
using PROJECT.IRepository.Interfaces.Security;
using PROJECT.Model.Security;
using PROJECT.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repository.Repositories.Security
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _db = dbContext;
        }
      
    }
}
