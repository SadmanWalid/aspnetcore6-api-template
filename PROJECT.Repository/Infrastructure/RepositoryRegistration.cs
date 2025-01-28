using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROJECT.Database.Database;
using PROJECT.IRepository.Infrastructure;
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

            // Add UnitOfWork Dependency Injection
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

    }

}
