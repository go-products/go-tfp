using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TFP.Core.Mapping;

namespace TFP.WebAPI.StartupExtensions
{
    public static class AutoMapperExtension
    {

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new TfpEventsMap());
            });

            return services;
        }
    }
}
