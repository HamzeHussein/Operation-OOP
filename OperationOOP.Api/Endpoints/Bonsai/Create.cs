namespace OperationOOP.Api.Endpoints;

public class CreateBonsai : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/bonsais", Handle)
        .WithSummary("Bonsai trees");

    public record Request(
        string Name,
        string Species,
        int AgeYears,
        DateTime LastWatered,
        DateTime LastPruned,
        BonsaiStyle Style,
        CareLevel CareLevel,
        string SoilType, // 🆕 Lagt till SoilType
        int DaysBetweenWatering // 🆕 Lagt till vattningsintervall
    );

    public record Response(int Id);

    private static Ok<Response> Handle(Request request, IDatabase db)
    {
        var bonsai = new Bonsai(
            id: db.Bonsais.Any() ? db.Bonsais.Max(b => b.Id) + 1 : 1,
            name: request.Name,
            species: request.Species,
            ageYears: request.AgeYears,
            lastWatered: request.LastWatered,
            lastPruned: request.LastPruned,
            style: request.Style,
            careLevel: request.CareLevel,
            soil: new Soil(request.SoilType, true), // 🆕 Fix: Skapa Soil-instans
            wateringSchedule: new WateringSchedule(request.DaysBetweenWatering) // 🆕 Fix: Skapa vattningsschema
        ); // 🆕 Fix: Slutparentes och semikolon

        db.Bonsais.Add(bonsai); // 🆕 Fix: Separerat från konstruktionen

        return TypedResults.Ok(new Response(bonsai.Id));
    }
}

