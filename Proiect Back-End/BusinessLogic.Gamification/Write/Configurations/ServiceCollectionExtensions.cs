using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Gamification.Write.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Gamification.Write.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccess(connectionString);
        }
    }
}
