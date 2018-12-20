using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ClassesManagement.Write.Configurations
{
    using DataAccess.ClassesManagement.Write.Abstractions;
    using DataAccess.ClassesManagement.Write.Implementations;

    public static class ServiceCollectionExtensios
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository,Repository>();
        }
    }
}
