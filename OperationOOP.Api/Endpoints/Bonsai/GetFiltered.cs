using OperationOOP.Core.Data;
using OperationOOP.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OperationOOP.Api.Endpoints;

public class GetFiltered : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/filter", Handle) // Skapar en GET-endpoint för filtrering av bonsaiträd
        .WithName("GetFilteredBonsais"); // Namnger endpointen i Swagger/OpenAPI

    public record Response(
        int Id,       // Bonsai-trädets unika ID
        string Name,  // Namnet på bonsai-trädet
        string Species, // Trädets art
        int AgeYears   // Trädets ålder i år
    );

    private static List<Response> Handle(IDatabase db)
    {
        // 🔹 Hämta alla bonsaiträd i databasen och logga antalet
        var allBonsais = db.Bonsais.ToList();
        Console.WriteLine($"Totalt antal bonsaiträd i databasen: {allBonsais.Count}");

        // 🔹 Filtrera bonsaiträd som är äldre än 5 år
        var filteredBonsais = allBonsais.Where(b => b.AgeYears > 5).ToList();
        Console.WriteLine($"Antal bonsaiträd efter filtrering (>5 år): {filteredBonsais.Count}");

        // 🔹 Returnera de filtrerade träden som en lista av Response-objekt
        return filteredBonsais
            .Select(b => new Response(
                Id: b.Id,
                Name: b.Name,
                Species: b.Species,
                AgeYears: b.AgeYears
            ))
            .ToList();
    }
}
