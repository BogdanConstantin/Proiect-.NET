using DataAccess.ClassesManagement.Write.Configurations;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLogic.ClassesManagement.Write.Configurations
{
    using BusinessLogic.ClassesManagement.Write.Abstractions;
    using BusinessLogic.ClassesManagement.Write.Implementations;

    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<ICourseLogic, CourseLogic>();
        }
    }
}
