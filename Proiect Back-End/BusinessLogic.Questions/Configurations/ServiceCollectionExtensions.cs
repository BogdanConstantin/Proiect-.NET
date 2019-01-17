using BusinessLogic.Questions.Abstractions;
using BusinessLogic.Questions.Implementations;
using DataAccess.Notifications.Configurations;

namespace BusinessLogic.Questions.Configurations
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IAnswerLogic, AnswerLogic>();
            services.AddScoped<IQuestionLogic, QuestionLogic>();
            services.AddScoped<IQuestionNotification, QuestionNotification>();
            services.AddScoped<IServiceClient, ServiceClient>();
        }
    }
}
