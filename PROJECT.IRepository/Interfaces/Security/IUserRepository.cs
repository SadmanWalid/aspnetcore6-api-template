using PROJECT.IRepository.Infrastructure;
using PROJECT.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.IRepository.Interfaces.Security
{
    public interface IUserRepository: IGenericRepository<User>
    {
        
    }
}
