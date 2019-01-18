using BusinessLogic.Gamification.Abstractions;
using BusinessLogic.Gamification.Implementations;

namespace BusinessLogic.Gamification.Configurations
{
    using DataAccess.Gamification.Configurations;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IServiceClient, ServiceClient>();
            services.AddScoped<ISessionNotification, SessionNotification>();
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IAnswerLogic, AnswerLogic>();
        }
    }
}
