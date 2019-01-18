namespace BusinessLogic.FilesHandler.Configurations
{
    using BusinessLogic.FilesHandler.Abstractions;
    using BusinessLogic.FilesHandler.Implementations;
    using DataAccess.FilesHandler.Configurations;

    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
            services.AddScoped<IFileClassesCommunication, FileClassesCommunication>();
            services.AddScoped<IFileNotification, FileNotification>();
            services.AddScoped<IFilesHandlerLogic, FileHandlerLogic>();
            services.AddScoped<IServiceClient, ServiceClient>();
        }
    }
}
