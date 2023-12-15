using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PilotStore_.Data;
using PilotStore_.Models;

namespace PilotStore_.Pages.Marcas
{
    public class CreateModel : PageModel
    {
        private readonly PilotStore_.Data.PilotStoreDbContext _context;

        public CreateModel(PilotStore_.Data.PilotStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Marca Marca { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Marca == null || Marca == null)
            {
                return Page();
            }

            _context.Marca.Add(Marca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
