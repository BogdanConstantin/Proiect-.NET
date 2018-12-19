using DataAccess.Questions.Write.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Questions.Write.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
        }
    }
}
