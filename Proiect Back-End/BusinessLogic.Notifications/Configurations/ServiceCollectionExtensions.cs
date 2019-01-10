namespace BusinessLogic.Notifications.Configurations
{
    using Abstractions;
    using Implementations;

    using DataAccess.Notifications.Configurations;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IEmailLogic, EmailLogic>();
        }
    }
}
