namespace DataAccess.ClassesManagement.Configurations
{
    using DataAccess.ClassesManagement.Abstractions;
    using DataAccess.ClassesManagement.Implementations;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensios
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository,Repository>();
        }
    }
}
