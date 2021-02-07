using GetSimple.WebAPI.Modelos;
using GetSimple.WebAPI.RegraDeNegocio;
using GetSimple.WebAPI.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.AuthProvider.Configuracao
{
    public static class InjecaoDeDependencias
    {
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddTransient<UsuarioNegocios>();
            services.AddTransient <UsuarioRepositorio>();
            services.AddTransient <UserManager<Usuario>>();
            services.AddTransient<SignInManager<Usuario>>();
            services.AddTransient<IRepositorio<Usuario>, RepositorioBaseEF<Usuario>>();

            return services;
        }
    }
}
