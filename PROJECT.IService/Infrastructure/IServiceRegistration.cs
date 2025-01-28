using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.IService.Infrastructure
{
    public interface IServiceRegistration
    {
        void AddInfrastructure(IServiceCollection services, string database);
       
    }
}
