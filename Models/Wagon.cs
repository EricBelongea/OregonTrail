using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrail.Models
{
    public class Wagon
    {
        public int WagonId { get; set; }
        public string Name { get; set; }
        public int NumWheels { get; set; }
        public bool Covered { get; set; }
        public ICollection<Passanger> Passangers { get; set; }
        public Caravan Caravan { get; set; }
        public int CaravanId { get; set; }
    }
}
