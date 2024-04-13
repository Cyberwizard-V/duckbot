using DuckAPI.Data;
using DuckAPI.Models;
using System.Diagnostics.Metrics;

namespace DuckAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Ducklores.Any())
            {
                string duckLore = "Warduck: Is a Duck soldier";
                string duckLore2 = "Chefduck: Is a Duck Chef";
                string duckLore3 = "Pirateduck: Is a Duck Pirate";

                var DuckLores = new List<Ducklore>()
        {
            new Ducklore() { Lore = duckLore },
            new Ducklore() { Lore = duckLore2 },
            new Ducklore() { Lore = duckLore3 }
        };

                dataContext.Ducklores.AddRange(DuckLores);
                dataContext.SaveChanges();
            }

            if (!dataContext.Ducks.Any())
            {
                var warduck = dataContext.Ducklores.FirstOrDefault(l => l.Lore == "Warduck: Is a Duck soldier");
                var chefduck = dataContext.Ducklores.FirstOrDefault(l => l.Lore == "Chefduck: Is a Duck Chef");
                var pirateduck = dataContext.Ducklores.FirstOrDefault(l => l.Lore == "Pirateduck: Is a Duck Pirate");

                var Ducks = new List<Duck>()
        {
            new Duck() { DuckName = "Brady", DuckGender = "Male", DuckColor = "Green", DuckloreID = warduck?.ID ?? 0},
            new Duck() { DuckName = "Robin", DuckGender = "Female", DuckColor = "White", DuckloreID = chefduck?.ID ?? 0},
            new Duck() { DuckName = "Kevin", DuckGender = "Male", DuckColor = "Purple", DuckloreID = pirateduck?.ID ?? 0}
        };

                dataContext.Ducks.AddRange(Ducks);
            }

            if (!dataContext.Duckusers.Any())
            {
                var Duckusers = new List<Duckuser>()
        {
            new Duckuser() { Duckusername = "Admin", DuckPW = "test", RoleID = 1 }
        };

                dataContext.Duckusers.AddRange(Duckusers);
            }

            dataContext.SaveChanges();
        }
    }
}
