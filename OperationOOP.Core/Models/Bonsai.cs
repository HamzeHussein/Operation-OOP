namespace OperationOOP.Core.Models;

public class Bonsai : Plant, IEntity

{
    public DateTime LastWatered { get; set; }
    public DateTime LastPruned { get; set; }
    public BonsaiStyle Style { get; set; }
    public CareLevel CareLevel { get; set; }
    public Soil Soil { get; set; }  // Ny egenskap f�r jordtyp
    public WateringSchedule WateringSchedule { get; set; } // Nytt vattningsschema

    // Konstruktor som kopierar dina befintliga egenskaper och l�gger till Soil + WateringSchedule
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

    // Implementerar metoderna fr�n Plant
    public override void Water()
    {
        LastWatered = DateTime.UtcNow;
        WateringSchedule.Water();  // Anv�nd `WateringSchedule` f�r att markera tr�det som vattnat
    }

    public override void Prune()
    {
        LastPruned = DateTime.UtcNow;
    }

    public bool NeedsWatering()
    {
        return WateringSchedule.NeedsWatering();  // Kontrollera om bonsaitr�det beh�ver vatten
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


