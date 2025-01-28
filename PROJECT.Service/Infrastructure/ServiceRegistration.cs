using Microsoft.Extensions.DependencyInjection;
using PROJECT.IRepository.Infrastructure;
using PROJECT.IService.Infrastructure;
using PROJECT.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Service.Infrastructure
{
    public class ServiceRegistration: IServiceRegistration
    {
        public static IRepositoryRegistration RepositoryRegistration   { get; set; } = new RepositoryRegistration();

        public void AddInfrastructure(IServiceCollection services, string database)
        {
            // Repository registration
            RepositoryRegistration.AddInfrastructure(services, database);

            // service registration DI
        }
    }
    
}
