using OperationOOP.Core.Data;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints;

public class SearchBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/search", Handle) // Skapar en GET-endpoint för att söka efter bonsaiträd
        .WithOpenApi() // Genererar OpenAPI-dokumentation
        .Produces<List<Response>>(); // Anger att svaret är en lista av Response-objekt

    // Request-klass som tar emot söktermen som parameter
    public record Request(string SearchTerm);

    // Response-klass som returnerar bonsai-trädets information
    public record Response(
        int Id,
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel
    );

    // Metoden som hanterar anropet till endpointen
    private static List<Response> Handle([AsParameters] Request request, IDatabase db)
    {
        return db.SearchBonsaisByName(request.SearchTerm) // Anropar databasens sökmetod
            .Select(b => new Response(
                Id: b.Id,
                Name: b.Name,
                Species: b.Species,
                AgeYears: b.AgeYears,
                LastWatered: b.LastWatered,
                LastPruned: b.LastPruned,
                Style: b.Style,
                CareLevel: b.CareLevel
            ))
            .ToList(); // Returnerar en lista av bonsaiträd som matchar sökningen
    }
}

