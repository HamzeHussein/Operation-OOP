namespace OperationOOP.Core.Models;

// Klass som representerar jordtypen för en bonsai
public class Soil
{
    // Typ av jord (t.ex. sandig, lerig, organisk)
    public string Type { get; private set; }

    // Anger om jorden är näringsrik eller inte
    public bool IsNutrientRich { get; private set; }

    // Konstruktor som initierar jordtyp och näringsstatus
    public Soil(string type, bool isNutrientRich)
    {
        Type = type;
        IsNutrientRich = isNutrientRich;
    }

    // Metod för att ändra jordtyp och uppdatera näringsstatus
    public void ChangeSoil(string newType, bool newNutrientStatus)
    {
        Type = newType;
        IsNutrientRich = newNutrientStatus;
    }
}

