using DataAccess.Gamification.Abstractions;
using DataAccess.Gamification.Implementations;

namespace DataAccess.Gamification.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensios
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();
        }
    }
}
