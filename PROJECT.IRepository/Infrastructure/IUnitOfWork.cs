using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.IRepository.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
