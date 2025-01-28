using PROJECT.IService.Infrastructure;
using PROJECT.Service.Infrastructure;

namespace PROJECT.API.DependencyInjection
{
    public static class Services
    {
        public static IServiceRegistration serviceRegistration{ get; set; } = new ServiceRegistration();

        public static void RegisterDependencies(IServiceCollection services, string database)
        {
            serviceRegistration.AddInfrastructure(services, database);
        }

    }
}
