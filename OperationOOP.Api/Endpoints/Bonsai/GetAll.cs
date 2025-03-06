namespace OperationOOP.Api.Endpoints;
public class GetAllBonsais : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    // Request and Response types
    public record Response(
        int Id,
        string Name,
        DateTime LastWatered,
        DateTime LastPruned
    );

    //Logic
    private static List<Response> Handle(IDatabase db)
    {
        return db.Bonsais
            .Select(item => new Response(
                Id: item.Id,
                Name: item.Name,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned
            )).ToList();
    }
}