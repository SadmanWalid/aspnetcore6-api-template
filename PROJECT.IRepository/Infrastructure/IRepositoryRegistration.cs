using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.IRepository.Infrastructure
{
    public interface IRepositoryRegistration
    {
        void AddInfrastructure(IServiceCollection services, string database);
    }
}
