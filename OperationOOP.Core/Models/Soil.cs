namespace OperationOOP.Core.Models;

public class Soil
{
    public string Type { get; private set; }
    public bool IsNutrientRich { get; private set; }

    public Soil(string type, bool isNutrientRich)
    {
        Type = type;
        IsNutrientRich = isNutrientRich;
    }

    public void ChangeSoil(string newType, bool newNutrientStatus)
    {
        Type = newType;
        IsNutrientRich = newNutrientStatus;
    }
}
