using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.FilesHandler.Write.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.FilesHandler.Write.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
        }
    }
}
