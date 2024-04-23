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
        public async Task<ICollection<Caravan>> LoadAllCaravans()
        {
            return await _context.Caravan.ToListAsync();
        }
    }
}
