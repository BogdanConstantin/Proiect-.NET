using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.ClassesManagement.Write.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.ClassesManagement.Write.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
        }
    }
}
