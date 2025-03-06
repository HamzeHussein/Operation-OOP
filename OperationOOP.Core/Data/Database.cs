using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }

        // Ny metod för att filtrera bonsaiträd efter skötselnivå (CareLevel)
        List<Bonsai> GetBonsaisByCareLevel(CareLevel careLevel);
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();

        // Implementering av metoden som filtrerar och sorterar bonsaiträd
        public List<Bonsai> GetBonsaisByCareLevel(CareLevel careLevel)
        {
            return Bonsais
                .Where(b => b.CareLevel == careLevel)
                .OrderByDescending(b => b.AgeYears) // Sorterar äldsta först
                .ToList();
        }
    }
}
