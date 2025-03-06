namespace OperationOOP.Core.Models;

public class WateringSchedule
{
    public int DaysBetweenWatering { get; private set; }
    public DateTime LastWatered { get; private set; }

    public WateringSchedule(int daysBetweenWatering)
    {
        DaysBetweenWatering = daysBetweenWatering;
        LastWatered = DateTime.UtcNow;
    }

    public bool NeedsWatering()
    {
        return (DateTime.UtcNow - LastWatered).TotalDays >= DaysBetweenWatering;
    }

    public void Water()
    {
        LastWatered = DateTime.UtcNow;
    }
}
