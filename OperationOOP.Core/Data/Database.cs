using OperationOOP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Bonsai> Bonsais { get; set; }

        // 🔹 Metod för att filtrera bonsaiträd efter skötselnivå (CareLevel)
        List<Bonsai> GetBonsaisByCareLevel(CareLevel careLevel);

        // 🔹 Ny metod för att filtrera bonsaiträd som behöver vattnas
        List<Bonsai> GetBonsaisNeedingWater();
    }

    public class Database : IDatabase
    {
        public List<Bonsai> Bonsais { get; set; } = new List<Bonsai>();

        // 🔹 Filtrerar och sorterar bonsaiträd efter skötselnivå
        public List<Bonsai> GetBonsaisByCareLevel(CareLevel careLevel)
        {
            return Bonsais
                .Where(b => b.CareLevel == careLevel)
                .OrderByDescending(b => b.AgeYears) // Sorterar äldsta först
                .ToList();
        }

        // 🔹 Ny metod för att hitta bonsaiträd som inte har vattnats på minst 7 dagar
        public List<Bonsai> GetBonsaisNeedingWater()
        {
            return Bonsais
                .Where(b => (DateTime.UtcNow - b.LastWatered).TotalDays >= 7)
                .ToList();
        }
    }
}

