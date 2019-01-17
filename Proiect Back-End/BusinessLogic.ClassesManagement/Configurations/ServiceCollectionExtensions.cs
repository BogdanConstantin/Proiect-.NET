namespace BusinessLogic.ClassesManagement.Configurations
{
    using Abstractions;
    using Implementations;

    using DataAccess.ClassesManagement.Configurations;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<ICourseLogic, CourseLogic>();
            services.AddScoped<ICourseManagementLogic, CourseManagementLogic>();
            services.AddScoped<ILaboratoryManagementLogic, LaboratoryManagementLogic>();
        }
    }
}
