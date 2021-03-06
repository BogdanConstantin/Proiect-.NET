﻿using DataAccess.Questions;
using DataAccess.Questions.Abstractions;
using DataAccess.Questions.Implementations;

namespace DataAccess.Notifications.Configurations
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensios
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();

        }
    }
}
