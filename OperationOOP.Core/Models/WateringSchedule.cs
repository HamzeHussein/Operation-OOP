namespace OperationOOP.Core.Models;

// Klass som hanterar vattningsschemat för en bonsai
public class WateringSchedule
{
    // Antal dagar mellan vattningar
    public int DaysBetweenWatering { get; private set; }

    // Senaste vattningstillfället
    public DateTime LastWatered { get; private set; }

    // Konstruktor som sätter vattningsintervallet och initierar senaste vattningstidpunkt till nuvarande tid
    public WateringSchedule(int daysBetweenWatering)
    {
        DaysBetweenWatering = daysBetweenWatering;
        LastWatered = DateTime.UtcNow;
    }

    // Metod som kontrollerar om bonsaiträdet behöver vattnas
    public bool NeedsWatering()
    {
        return (DateTime.UtcNow - LastWatered).TotalDays >= DaysBetweenWatering;
    }

    // Metod för att uppdatera senaste vattningstillfället till nuvarande tidpunkt
    public void Water()
    {
        LastWatered = DateTime.UtcNow;
    }
}

