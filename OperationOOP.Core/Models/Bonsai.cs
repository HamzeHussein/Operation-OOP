namespace OperationOOP.Core.Models;

public class Bonsai : Plant, IEntity

{
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public BonsaiStyle Style { get; set; }
    public CareLevel CareLevel { get; set; }
    public Soil Soil { get; set; }  // Ny egenskap för jordtyp
    public WateringSchedule WateringSchedule { get; set; } // Nytt vattningsschema

    // Konstruktor som kopierar dina befintliga egenskaper och lägger till Soil + WateringSchedule
    public Bonsai(int id, string name, string species, int ageYears, DateTime lastWatered, DateTime lastPruned,
                  BonsaiStyle style, CareLevel careLevel, Soil soil, WateringSchedule wateringSchedule)
        : base(id, name, species, ageYears)
    {
        LastWatered = lastWatered;
        LastPruned = lastPruned;
        Style = style;
        CareLevel = careLevel;
        Soil = soil;
        WateringSchedule = wateringSchedule;
    }

    // Implementerar metoderna från Plant
    public override void Water()
    {
        LastWatered = DateTime.UtcNow;
        WateringSchedule.Water();  // Använd `WateringSchedule` för att markera trädet som vattnat
    }

    public override void Prune()
    {
        LastPruned = DateTime.UtcNow;
    }

    public bool NeedsWatering()
    {
        return WateringSchedule.NeedsWatering();  // Kontrollera om bonsaiträdet behöver vatten
    }
}

public enum BonsaiStyle
{
    Chokkan,    // Formal Upright
    Moyogi,     // Informal Upright
    Shakan,     // Slanting
    Kengai,     // Cascade
    HanKengai   // Semi-cascade
}

public enum CareLevel
{
    Beginner,
    Intermediate,
    Advanced,
    Master
}


