using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROJECT.Database.Database;
using PROJECT.IRepository.Infrastructure;
using PROJECT.IRepository.Interfaces.Security;
using PROJECT.Repository.Repositories.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Repository.Infrastructure
{
    public class RepositoryRegistration : IRepositoryRegistration
    {
        public void AddInfrastructure(IServiceCollection services, string database)
        {
            // database
            services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(database,
                    options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null));
            });

            // Register Repositories DI
            services.AddTransient<IUserRepository, UserRepository>();

            // Add UnitOfWork Dependency Injection
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

    }

}
