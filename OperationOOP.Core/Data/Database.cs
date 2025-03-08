using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }

        // Metod för att filtrera bonsaiträd efter skötselnivå (CareLevel)
        List<Bonsai> GetBonsaisByCareLevel(CareLevel careLevel);

        // Metod för att filtrera bonsaiträd som behöver vattnas
        List<Bonsai> GetBonsaisNeedingWater();

        // Metod för att söka efter bonsaiträd baserat på namn
        List<Bonsai> SearchBonsaisByName(string searchTerm);
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();

        // Filtrerar och sorterar bonsaiträd efter skötselnivå
        public List<Bonsai> GetBonsaisByCareLevel(CareLevel careLevel)
        {
            return Bonsais
                .Where(b => b.CareLevel == careLevel) // Hittar träd med rätt skötselnivå
                .OrderByDescending(b => b.AgeYears) // Sorterar efter ålder, äldst först
                .ToList();
        }

        // Metod för att hitta bonsaiträd som inte har vattnats på minst 7 dagar
        public List<Bonsai> GetBonsaisNeedingWater()
        {
            return Bonsais
                .Where(b => (DateTime.UtcNow - b.LastWatered).TotalDays >= 7) // Kollar om det har gått mer än 7 dagar sedan senaste vattning
                .ToList();
        }

        // Metod för att söka efter bonsaiträd baserat på namn (case insensitive)
        public List<Bonsai> SearchBonsaisByName(string searchTerm)
        {
            return Bonsais
                .Where(b => b.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) // Söker efter namn som innehåller sökordet
                .ToList();
        }
    }
}
