using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OperationOOP.Api.Endpoints;
using OperationOOP.Core.Data;

namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            ConfigureMiddleware(app);

            // Start the application
            app.Run();
        }

        /// <summary>
        /// Configures services (Dependency Injection)
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Add authorization services
            services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            // Add Database as a singleton service
            services.AddSingleton<IDatabase, Database>();

            // Add Controllers (for future expansion if needed)
            services.AddControllers();
        }

        /// <summary>
        /// Configures middleware and API request pipeline
        /// </summary>
        private static void ConfigureMiddleware(WebApplication app)
        {
            // Enable Swagger in Development mode
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Force HTTPS for security
            app.UseHttpsRedirection();

            // Enable Authorization
            app.UseAuthorization();

            // Map API endpoints
            app.MapEndpoints<Program>();

            // If using Controllers, enable them
            app.MapControllers();
        }
    }
}

