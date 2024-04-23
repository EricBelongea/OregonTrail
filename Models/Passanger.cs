using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrail.Models
{
    public class Passanger
    {
        public int PassangerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Destination { get; set; }
        public Wagon Wagon { get; set; }
        public int WagonId { get; set; }
    }
}
