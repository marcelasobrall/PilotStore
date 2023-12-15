using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PilotStore_.Data;
using PilotStore_.Models;

namespace PilotStore_.Pages.Marcas
{
    public class IndexModel : PageModel
    {
        private readonly PilotStore_.Data.PilotStoreDbContext _context;

        public IndexModel(PilotStore_.Data.PilotStoreDbContext context)
        {
            _context = context;
        }

        public IList<Marca> Marca { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Marca != null)
            {
                Marca = await _context.Marca.ToListAsync();
            }
        }
    }
}
