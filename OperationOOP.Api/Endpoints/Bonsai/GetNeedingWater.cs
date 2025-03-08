using OperationOOP.Core.Data;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints;
public class GetNeedingWater : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/needing-water", Handle)
        .WithSummary("Hämtar alla bonsaiträd som behöver vattnas");

    public record Response(
        int Id,
        string Name,
        DateTime LastWatered,
        int DaysBetweenWatering
    );

    private static List<Response> Handle(IDatabase db)
    {
        return db.Bonsais
            .Where(b => (DateTime.UtcNow - b.LastWatered).TotalDays >= b.WateringSchedule.DaysBetweenWatering)
            .Select(b => new Response(
                Id: b.Id,
                Name: b.Name,
                LastWatered: b.LastWatered,
                DaysBetweenWatering: b.WateringSchedule.DaysBetweenWatering
            ))
            .ToList();
    }
}
