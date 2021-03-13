using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace GetSimple.WebAPI.AuthProvider.Configuracao
{
    public static class AutenticacaoJWT
    {
        public static IServiceCollection ResolveAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["KeyJWT"];
            var schema = JwtBearerDefaults.AuthenticationScheme;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = schema;
                options.DefaultChallengeScheme = schema;
            }).AddJwtBearer(schema, options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
                    ClockSkew = TimeSpan.FromHours(12)
                };
            });

            return services;
        }
    }
}
