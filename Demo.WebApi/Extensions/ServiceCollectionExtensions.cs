using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.DataAccess;
using Demo.Repositories.Interfaces;
using Demo.Repositories.Repositories;
using Demo.Services.Implementation;
using Demo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();

            return services;
        }

        public static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetConnectionString("SchoolDB");
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(config));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }
    }
}
