using System;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class ApplicationServicesRegistration
    {

        public static object AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;

        }
    }
}
