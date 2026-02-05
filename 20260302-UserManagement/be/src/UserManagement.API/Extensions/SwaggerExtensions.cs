using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace UserManagement.API.Extensions;

public static class SwaggerExtensions
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = configuration["Swagger:Title"] ?? "User Management API",
                    Version = "v1",
                    Description = configuration["Swagger:Description"] ?? "API Documentation for User Management Project",
                    Contact = new OpenApiContact
                    {
                        Name = "Hung Nguyen Thanh",
                        Email = "hugnt.dev@gmail.com",
                        Url = new Uri("https://github.com/hugnt")
                    }
                });
            });
        }
        public static void SwaggerConfig(this IApplicationBuilder app, IConfiguration configuration, string swaggerConfigName = "SwaggerConfig")
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string endPoint = configuration[$"{swaggerConfigName}:EndPoint"] ?? "/swagger/v1/swagger.json";
                string title = configuration[$"{swaggerConfigName}:Title"] ?? "User Management API Documentation";

                c.SwaggerEndpoint(endPoint, title);
                c.DocumentTitle = $"{title} Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }
    }