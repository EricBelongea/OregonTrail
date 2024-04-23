using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrail.Models
{
    public class Caravan
    {
        public int CaravanId { get; set; }
        public string Name { get; set; }
        public ICollection<Wagon> Wagons { get; set; }
    }
}
