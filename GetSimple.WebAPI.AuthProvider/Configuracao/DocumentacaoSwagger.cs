using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GetSimple.WebAPI.AuthProvider.Configuracao
{
    public static class DocumentacaoSwagger
    {
        public static IServiceCollection ResolveSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GetSimple.WebAPI",
                    Description = "Documentação da WebAPI do projeto GetSimple",
                    Version = "v1"
                });

                options.EnableAnnotations();
            });


            return services;
        }
    }
}
