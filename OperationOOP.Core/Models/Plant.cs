namespace OperationOOP.Core.Models;

public abstract class Plant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public int AgeYears { get; set; }

    public Plant(int id, string name, string species, int ageYears)
    {
        Id = id;
        Name = name;
        Species = species;
        AgeYears = ageYears;
    }

    public abstract void Water();
    public abstract void Prune();
}
