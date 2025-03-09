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

            // Lägger till tjänster i DI-containern
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Konfigurerar middleware och request pipeline
            ConfigureMiddleware(app);

            // Startar applikationen
            app.Run();
        }

        /// <summary>
        /// Konfigurerar tjänster (Dependency Injection)
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Lägger till behörighetskontroll
            services.AddAuthorization();

            // Lägger till Swagger för API-dokumentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            // Lägger till en databas som singleton-tjänst
            services.AddSingleton<IDatabase, Database>();

            // Lägger till stöd för controllers (om det behövs i framtiden)
            services.AddControllers();
        }

        /// <summary>
        /// Konfigurerar middleware och HTTP-requesthantering
        /// </summary>
        private static void ConfigureMiddleware(WebApplication app)
        {
            // Aktiverar Swagger i utvecklingsläge
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Tvingar användning av HTTPS för säkerhet
            app.UseHttpsRedirection();

            // Aktiverar behörighetskontroll
            app.UseAuthorization();

            // Mappar API-endpoints
            app.MapEndpoints<Program>();

            // Aktiverar controllers om de används
            app.MapControllers();
        }
    }
}


