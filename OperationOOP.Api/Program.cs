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

            // L�gger till tj�nster i DI-containern
            ConfigureServices(builder.Services);

            var app = builder.Build();

            // Konfigurerar middleware och request pipeline
            ConfigureMiddleware(app);

            // Startar applikationen
            app.Run();
        }

        /// <summary>
        /// Konfigurerar tj�nster (Dependency Injection)
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // L�gger till beh�righetskontroll
            services.AddAuthorization();

            // L�gger till Swagger f�r API-dokumentation
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            // L�gger till en databas som singleton-tj�nst
            services.AddSingleton<IDatabase, Database>();

            // L�gger till st�d f�r controllers (om det beh�vs i framtiden)
            services.AddControllers();
        }

        /// <summary>
        /// Konfigurerar middleware och HTTP-requesthantering
        /// </summary>
        private static void ConfigureMiddleware(WebApplication app)
        {
            // Aktiverar Swagger i utvecklingsl�ge
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Tvingar anv�ndning av HTTPS f�r s�kerhet
            app.UseHttpsRedirection();

            // Aktiverar beh�righetskontroll
            app.UseAuthorization();

            // Mappar API-endpoints
            app.MapEndpoints<Program>();

            // Aktiverar controllers om de anv�nds
            app.MapControllers();
        }
    }
}


