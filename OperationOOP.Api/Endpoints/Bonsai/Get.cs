namespace OperationOOP.Api.Endpoints;

public class GetBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/{id}", Handle)
        .WithSummary("Bonsai trees");

    public record Request(int Id);

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

    private static Response Handle([AsParameters] Request request, IDatabase db)
    {
        // Find the bonsai by ID
        var bonsai = db.Bonsais.FirstOrDefault(b => b.Id == request.Id);

        // Handle case where bonsai is not found
        if (bonsai == null)
        {
            throw new Exception($"Bonsai with ID {request.Id} not found");
        }

        // Map bonsai to response DTO
        var response = new Response(
            Id: bonsai.Id,
            Name: bonsai.Name,
            Species: bonsai.Species,
            AgeYears: bonsai.AgeYears,
            LastWatered: bonsai.LastWatered,
            LastPruned: bonsai.LastPruned,
            Style: bonsai.Style,
            CareLevel: bonsai.CareLevel
        );

        return response;
    }
}


