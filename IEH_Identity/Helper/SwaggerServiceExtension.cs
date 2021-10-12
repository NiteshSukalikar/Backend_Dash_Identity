using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.Helper
{
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// The AddSwaggerDocumentation
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/></param>
        /// <returns>The <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Main API v1.0", Version = "v1.0" });

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });
                //c.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }

        /// <summary>
        /// The UseSwaggerDocumentation
        /// </summary>
        /// <param name="app">The app<see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");
            });

            return app;
        }
    }

}
