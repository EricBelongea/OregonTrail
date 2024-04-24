using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrail.Models
{
    internal class Utilities
    {
        private readonly CaravanContext _context;

        internal Utilities(CaravanContext context)
        {
            _context = context;
        }
        public async Task<List<Caravan>> LoadAllCaravans()
        {
            return await _context.Caravan.ToListAsync();
        }

        public Caravan GetCaravanWithWagon(int caravanId)
        {
            return _context.Caravan.Include(c => c.Wagons).FirstOrDefault(c => c.CaravanId == caravanId);
        }

        public Caravan GetCaravanWithWagonAndPassengers(int caravanId)
        {
            return _context.Caravan.Include(c => c.Wagons).ThenInclude(w => w.Passangers).FirstOrDefault(c => c.CaravanId == caravanId);
        }

        public void CountOfWagons(int caravanId)
        {
            Caravan caravan = GetCaravanWithWagon(caravanId);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"In '{caravan.Name}' there are {caravan.Wagons.Count} wagons");
            Console.WriteLine("What else would you like to do?");
        }

        public void PassengersPerWagon(int caravanId)
        {
            Caravan caravan = GetCaravanWithWagonAndPassengers(caravanId);
            foreach (Wagon wagon in caravan.Wagons)
            {
                Console.WriteLine($"In wagon '{wagon.Name}' there are {wagon.Passangers.Count()} passengers");
            }
        }

        public void UniqueDestinations(int caravanId)
        {
            List<string> uniqueDestinations = _context.Caravan
                .Where(c => c.CaravanId == caravanId)
                .SelectMany(c => c.Wagons.SelectMany(w => w.Passangers.Select(p => p.Destination)))
                .Distinct()
                .ToList();
            Console.WriteLine($"There are {uniqueDestinations.Count} Unique Destinations");
            for (int i = 0; i < uniqueDestinations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {uniqueDestinations[i]}");
            }
        }

        public void AverageAgeOfAll(int caravanId)
        {
            int age = (int)_context.Caravan.Where(c => c.CaravanId == caravanId)
                .SelectMany(c => c.Wagons.SelectMany(w => w.Passangers))
                .Average(p => p.Age);
            Console.WriteLine($"The average age for this caravan is {age}");
        }

        public void AverageAgeEachWagon(int caravanId)
        {
            var averageAgeByWagon = _context.Caravan
                 .Where(c => c.CaravanId == caravanId)
                 .SelectMany(c => c.Wagons)
                 .Select(w => new
                 {
                     WagonName = w.Name,
                     AverageAge = (int?)w.Passangers.Average(p => p.Age)
                 })
                 .ToList();
            for (int i = 0; i < averageAgeByWagon.Count; i++)
            {
                Console.WriteLine($"In wagon '{averageAgeByWagon[i].WagonName}' \nThe Average age is {averageAgeByWagon[i].AverageAge}");
            }
        }

        public void PassengerAndWagonNames(int caravanId)
        {
            var roster = _context.Caravan
                .Where(c => c.CaravanId == caravanId)
                .SelectMany(c => c.Wagons
                .Select(w => new
                {
                    WagonName = w.Name,
                    PassengerNames = w.Passangers.Select(p => p.Name).ToList()
                })).ToList();
            for (int i = 0; i < roster.Count; i++)
            {
                Console.WriteLine($"{i + 1}. In wagon '{roster[i].WagonName}'");
                foreach (var p in roster[i].PassengerNames)
                {
                    Console.WriteLine($"- {p}");
                }
            }
        }
    }
}
