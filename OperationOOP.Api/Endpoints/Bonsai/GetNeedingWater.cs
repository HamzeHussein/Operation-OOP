using OperationOOP.Core.Data;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints;


public class GetNeedingWater : IEndpoint
{
    
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/bonsais/needing-water", Handle)
        .WithSummary("Hämtar alla bonsaiträd som behöver vattnas");

    public record Response(
        int Id,                 // Bonsaiträdets unika ID
        string Name,            // Bonsaiträdets namn
        DateTime LastWatered,   // Datum för senaste vattning
        int DaysBetweenWatering // Antal dagar mellan vattningar
    );

    
    private static List<Response> Handle(IDatabase db)
    {
        return db.Bonsais
            .Where(b =>
                b.WateringSchedule != null && // Säkerhetskontroll för att undvika null-referens
                (DateTime.UtcNow - b.LastWatered).TotalDays >= b.WateringSchedule.DaysBetweenWatering // Kollar om det är dags att vattna
            )
            .Select(b => new Response(
                Id: b.Id,
                Name: b.Name,
                LastWatered: b.LastWatered,
                DaysBetweenWatering: b.WateringSchedule.DaysBetweenWatering
            ))
            .ToList();
    }
}
