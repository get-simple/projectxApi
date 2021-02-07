using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.AuthProvider.Configuracao
{
    public static class AutenticacaoJWT
    {
        public static IServiceCollection ResolveAutenticacao(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("GetSimple-WebAPI-Authentication-Valid")),
                    ClockSkew = TimeSpan.FromMinutes(10),
                    ValidIssuer = "GetSimple.WebAPI.AuthProvider"
                };
            });
            
            return services;
        }
    }
}
